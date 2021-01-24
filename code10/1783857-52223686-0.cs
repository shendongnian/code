    Get["/data", true] = async (param, cancellationToken) =>
        {
            string json;
            try
            {
                using (var sr = new StreamReader("file.json"))
                {
                    json = await sr.ReadToEndAsync();
                }
            }
            catch (Exception e)
            {
                return HttpStatusCode.InternalServerError;
            }
            return json;
        };
