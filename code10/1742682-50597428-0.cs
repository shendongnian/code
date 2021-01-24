        public UserCustom GetUserByToken(string pToken)
        {
            ResponseLogin vRespuesta = new ResponseLogin();
            UserCarmocal vUsuarioFinal = null;
            string vApiKey = ConfigurationManager.AppSettings["ApiKey"];
            string vDirUser = ConfigurationManager.AppSettings["EndpointUsr"];
            WebRequest request = WebRequest.Create(vDirUser);
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.Headers.Add("ApiKey", vApiKey);
            var bytes = System.Text.Encoding.UTF8.GetBytes(pToken);
            var stream = request.GetRequestStream();
            stream.Write(bytes, 0, bytes.Length);
            stream.Flush();
            using (Stream s = request.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    vRespuesta = new JavaScriptSerializer().Deserialize<ResponseLogin>(sr.ReadToEnd());
                    if (vRespuesta.status == "success")
                    { vUsuarioFinal.FirstName = "Test"; }
                }
            }
            return vUsuarioFinal;
        }
