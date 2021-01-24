     public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "options", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");
            if (!req.Content.IsMimeMultipartContent())
            {
                return req.CreateErrorResponse(HttpStatusCode.BadRequest,new Exception("UnSupported Meida Type"));
            }
            var provider = new MultipartFormDataStreamProvider(Path.GetTempPath());
            try
            {
                // Read the form data.
                await req.Content.ReadAsMultipartAsync(provider);
            }
            catch (System.Exception e)
            {
                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            var formData = provider.FormData;
            var apiKey = "apiEkey";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("no_reply@domain.com", "Auto Generated");
            var subject = "Application for " + formData["position"];
            var to = new EmailAddress("toemail", "Admin");
            var plainTextContent = subject;
            var htmlContent = $"<strong>First Name :</strong> {formData["firstname"]}<br><strong>Last Name :</strong> {formData["lastname"]}<br><strong>Phone Number :</strong> {formData["phonenumber"]}<br><strong>Email :</strong> {formData["email"]}";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            foreach (MultipartFileData file in provider.FileData)
            {
                var bytes = File.ReadAllBytes(file.LocalFileName);
                var fileBase64 = Convert.ToBase64String(bytes);
                string fileName = file.Headers.ContentDisposition.FileName;
                if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                {
                    fileName = fileName.Trim('"');
                }
                msg.AddAttachment(fileName, fileBase64);
            }
            client.SendEmailAsync(msg);
         
           return req.CreateResponse(HttpStatusCode.OK);
        }
