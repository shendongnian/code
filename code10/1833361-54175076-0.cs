    private string GetProtocolPath()
        {
            try
            {
                string path = _config.GetSection("ProtocolPath").GetValue<string>("PathToFolder");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                StringBuilder pathBuilder = new StringBuilder()
                    .Append(path)
                    .Append("\\")
                    .Append(DateTime.Now.ToString("yyyyMMdd"))
                    .Append(".xml");
                return pathBuilder.ToString();
            }
            catch (Exception ex)
            {
                var msg = $"{ex.Message} : {ex.InnerException}";
                Console.WriteLine(msg);
                throw;
            }
        }
