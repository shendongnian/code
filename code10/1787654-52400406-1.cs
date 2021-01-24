    public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "customer/{param1}/{param2}")]HttpRequestMessage req, string param1, string param2, TraceWriter log, ExecutionContext context)
     {
    
         //get the route params by calling the helper function
         GetRouteParams(context, log);
         //my body
     }
        public static void GetRouteParams(ExecutionContext context, TraceWriter log)
        {
            //function.json is under function directory
            using (StreamReader r = File.OpenText(context.FunctionDirectory + "/function.json"))
            {
                // Deserialize json
                dynamic jObject = JsonConvert.DeserializeObject(r.ReadToEnd());
                string route = jObject.bindings[0].route.ToString();
                // Search params name included in brackets
                Regex regex = new Regex(@"(?<=\{)[^}]*(?=\})", RegexOptions.IgnoreCase);
                MatchCollection matches = regex.Matches(route);
                var list = matches.Cast<Match>().Select(m => m.Value).Distinct().ToList();
                log.Info("[" + string.Join(", ", list) + "]");
            }
        }
