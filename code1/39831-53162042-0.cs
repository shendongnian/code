        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Status()
        {
            MyObject myObject = new MyObject(); // Your class here
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(myObject);
            HttpContext.Current.Response.Write(json);
        }
