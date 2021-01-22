                var response = (HttpWebRequest)WebRequest.Create("http://localhost:4433/");
            
                response.CookieContainer.Add(new Cookie("Name", "Value"));
                await response.GetResponseAsync();
                using (var requestStream = response.GetRequestStream())
                {
                   using (var streamWriter = new StreamWriter(requestStream))
                   {
                        requestStream.Write(RequestContent);
                   }
                }
            
