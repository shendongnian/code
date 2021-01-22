      internal class FormCookieServiceAuthorizationManager : ServiceAuthorizationManager
      {
         public override bool CheckAccess(OperationContext operationContext)
         {
            ParseFormsCookie(operationContext.RequestContext.RequestMessage);
            return base.CheckAccess(operationContext);
         }
         private static void ParseFormsCookie(Message message)
         {
            HttpRequestMessageProperty httpRequest = message.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
            if (httpRequest == null) return;
            string cookie = httpRequest.Headers[HttpRequestHeader.Cookie];
            if (string.IsNullOrEmpty(cookie)) return;
            string regexp = Regex.Escape(FormsAuthentication.FormsCookieName) + "=(?<val>[^;]+)";
            var myMatch = Regex.Match(cookie, regexp);
            if (!myMatch.Success) return;
            string cookieVal = myMatch.Groups["val"].ToString();
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(cookieVal);
            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(authTicket.Name), new string[0]);
         }
      }
      internal class CustomAuthorizationPolicy : IAuthorizationPolicy
      {
         static readonly string _id = Guid.NewGuid().ToString();
         public string Id
         {
            get { return _id; }
         }
         public bool Evaluate(EvaluationContext evaluationContext, ref object state)
         {
            evaluationContext.Properties["Principal"] = Thread.CurrentPrincipal;
            evaluationContext.Properties["Identities"] = new List<IIdentity> { Thread.CurrentPrincipal.Identity };
            return true;
         }
         public ClaimSet Issuer
         {
            get { return ClaimSet.System; }
         }
      }
