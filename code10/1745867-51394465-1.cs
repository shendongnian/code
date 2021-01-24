    [WebMethod]
    public string SavePackage(string args = "{}")
    {
        try
        {
            // here i am accepting json args as parameter
            string sourcePath = string.Empty, type = string.Empty, category = string.Empty, description = string.Empty, additionalComments = string.Empty;
            var jsonargs = (JObject)JsonConvert.DeserializeObject(args);
    
            if (jsonargs.Count == 0)
            {
                return "{'message':'No parameters', 'status':'404'}";
            }
    
            foreach (var item in jsonargs)
            {
                sourcePath = (item.Key.ToLower() != "sourcepath" || !string.IsNullOrEmpty(sourcePath)) ? sourcePath : item.Value.ToString().Replace(@"""", "").Replace(@"\\", @"\"); // shared path
                type = (item.Key.ToLower() != "type" || !string.IsNullOrEmpty(type)) ? type : item.Value.ToString().Replace(@"""", "");
                category = (item.Key.ToLower() != "category" || !string.IsNullOrEmpty(category)) ? category : item.Value.ToString().Replace(@"""", "");
                description = (item.Key.ToLower() != "description" || !string.IsNullOrEmpty(description)) ? description : item.Value.ToString().Replace(@"""", "");
                additionalComments = (item.Key.ToLower() != "additionalcomments" || !string.IsNullOrEmpty(additionalComments)) ? additionalComments : item.Value.ToString().Replace(@"""", "");
            }
    
            if (!Path.GetExtension(sourcePath).Equals(".zip"))
            {
                return "{'message':'File source path is not in a zip format', 'status':'404'}";
            }
    
            var filename = sourcePath.Remove(0, sourcePath.LastIndexOf("\\", StringComparison.Ordinal) + 1);    
            var tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDir);
            var destPath = Path.Combine(tempDir, filename);
            File.Copy(sourcePath, destPath, true);
    
            if (!File.Exists(destPath))
            {
                return "{'message':'File not copied', 'status':'404'}";
            }
    
            return "{'message':'OK', 'status':'200'}";
        }
        catch (Exception ex)
        {
            return "{'message':'error', 'status':'404'}";
        }
    }
