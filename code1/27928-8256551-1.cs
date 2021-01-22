        /// <summary>
        /// ActionMethodSelector to enable submit buttons to execute specific action methods.
        /// </summary>
        public class AcceptParameterAttribute : ActionMethodSelectorAttribute
       {
            /// <summary>
            /// Gets or sets the value to use to inject the index into
            /// </summary>
           public string TargetArgument { get; set; }
     
           /// <summary>
           /// Gets or sets the value to use in submit button to identify which method to select. This must be unique in each controller.
           /// </summary>
           public string Action { get; set; }
     
           /// <summary>
           /// Gets or sets the regular expression to match the action.
           /// </summary>
           public string ActionRegex { get; set; }
     
           /// <summary>
           /// Determines whether the action method selection is valid for the specified controller context.
           /// </summary>
           /// <param name="controllerContext">The controller context.</param>
           /// <param name="methodInfo">Information about the action method.</param>
           /// <returns>true if the action method selection is valid for the specified controller context; otherwise, false.</returns>
           public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
           {
     
               if (controllerContext == null)
               {
                   throw new ArgumentNullException("controllerContext");
               }
     
               Func<NameValueCollection> formGetter;
               Func<NameValueCollection> queryStringGetter;
     
               ValidationUtility.GetUnvalidatedCollections(HttpContext.Current, out formGetter, out queryStringGetter);
     
               var form = formGetter();
               var queryString = queryStringGetter();
     
               var req = form.AllKeys.Any() ? form : queryString;
     
               if (!string.IsNullOrEmpty(this.ActionRegex))
               {
                   foreach (var key in req.AllKeys.Where(k => k.StartsWith(Action, true, System.Threading.Thread.CurrentThread.CurrentCulture)))
                   {
                       if (key.Contains(":"))
                       {
                           if (key.Split(':').Count() == this.ActionRegex.Split(':').Count())
                           {
                               bool match = false;
                               for (int i = 0; i < key.Split(':').Count(); i++)
                               {
                                   if (Regex.IsMatch(key.Split(':')[0], this.ActionRegex.Split(':')[0]))
                                   {
                                       match = true;
                                   }
                                   else
                                   {
                                       match = false;
                                       break;
                                   }
                               }
     
                               if (match)
                               {
                                   return !string.IsNullOrEmpty(req[key]);
                               }
                           }
                       }
                       else
                       {
                           if (Regex.IsMatch(key, this.Action + this.ActionRegex))
                           {
                               return !string.IsNullOrEmpty(req[key]);
                           }
                       }
     
                   }
                   return false;
               }
               else
               {
                   return req.AllKeys.Contains(this.Action);
               }
           }
       }
