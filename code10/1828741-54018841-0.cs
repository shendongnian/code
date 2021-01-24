    WebRequest request = WebRequest.Create("http://localhost:60956/api/values");
        
            YClass yClass = new YClass() { Completion = 5, Message = "AA", Result = "Result" };
            JavaScriptSerializer serialize = new JavaScriptSerializer(); // the object is used to serialize the data , you could use any object that could serialize data
            byte[] objectContent = Encoding.UTF8.GetBytes(serialize.Serialize(yClass));
            request.ContentLength = objectContent.Length;
            request.ContentType = "application/json";
            request.Method = "POST";
            using (var stream = request.GetRequestStream())
            {
                stream.Write(objectContent, 0, objectContent.Length);
                stream.Close();
            }
            var resp = request.GetResponse();
            using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
            {
                string s = sr.ReadToEnd();
                System.Console.WriteLine(s);
            }
