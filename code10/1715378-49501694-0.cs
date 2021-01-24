    public class ActionInjectDateTimeFromUnixActionWebApiFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var objectContent = actionExecutedContext.Response.Content as ObjectContent;
            if (objectContent != null)
            {
                //var type = objectContent.ObjectType; //type of the returned object
                var value = objectContent.Value; //holding the returned value
                var dd = JObject.FromObject(value);
                var injection = RecursiveInjectUnixToDateTime(JObject.FromObject(value)); // recursively inject value
                objectContent.Value = injection;
                // Overwrite return value
                actionExecutedContext.Response.Content = objectContent;
            }
        }
        /// <summary>
        /// Recursive DateTime Injection 
        /// </summary>
        /// <param name="obj">'obj' need to be a JObject</param>
        /// <returns></returns>
        private dynamic RecursiveInjectUnixToDateTime(JToken obj)
        {
            var expObj = new ExpandoObject() as IDictionary<string, Object>;
            foreach (JProperty p in obj)
            {
                string name = p.Name;
                JToken value = p.Value;
                switch (value.Type)
                {
                    case JTokenType.Integer:
                        {
                            // Make sure your int is a date time after, after all isn't sure you are returning an int or a UNIX date time
                            if (value.Type == JTokenType.Integer && IsValidDateTime(value))
                            {
                                expObj.Add(name + "_DateTime", UnixToDateTime((long) value));
                            }
                            else
                            {
                                expObj.Add(name, value);
                            }
                        }
                        break;
                    case JTokenType.Object:
                        {
                            // Go deep
                            // expObj[name] = RecursiveInjectUnixToDateTime(p.Value);
                            expObj.Add(name, RecursiveInjectUnixToDateTime(p.Value));
                        }
                        break;
                    case JTokenType.Array:
                        {
                            // Go deep
                            var arr = new List<dynamic>();
                            foreach (var val in value.ToArray())
                            {
                                arr.Add(RecursiveInjectUnixToDateTime(val));
                            }
                            // expObj[name] = arr;
                            expObj.Add(name, arr);
                        }
                        break;
                    default:
                        {
                            // expObj[name] = value;
                            expObj.Add(name, value);
                        }
                        break;
                }
            }
            return expObj;
        }
        /// <summary>
        /// Validate if long value is a valid date time between 2000 and current year
        /// </summary>
        /// <param name="longUnix"></param>
        /// <returns></returns>
        private bool IsValidDateTime(JToken longUnix)
        {
            long unixDateTime = (long)longUnix;
            if (unixDateTime > 0)
            {
                try
                {
                    var date = UnixToDateTime(unixDateTime);
                    return date.Year >= 2000 && date.Year <= DateTime.UtcNow.Year;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }
        private DateTime UnixToDateTime(long unixTimestamp)
        {
            DateTime unixYear0 = new DateTime(1970, 1, 1);
            long unixTimeStampInTicks = unixTimestamp * TimeSpan.TicksPerSecond;
            DateTime dtUnix = new DateTime(unixYear0.Ticks + unixTimeStampInTicks);
            return dtUnix;
        }
    }
