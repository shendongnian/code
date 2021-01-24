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
                logging.WriteLog("Nothing found - no parameters passed");
                logging.WriteLog("------------------------------------------------------------------------------------------");
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
    
            logging.WriteLog("---Parameters to update");
            logging.WriteLog("source path - " + sourcePath);
            logging.WriteLog("type - " + type);
            logging.WriteLog("category - " + category);
            logging.WriteLog("description - " + description);
            logging.WriteLog("additional comments - " + additionalComments);
    
            if (!Path.GetExtension(sourcePath).Equals(".zip"))
            {
                logging.WriteLog("File source path is not in a zip format");
                logging.WriteLog("------------------------------------------------------------------------------------------");
                return "{'message':'File source path is not in a zip format', 'status':'404'}";
            }
    
            logging.WriteLog("---File related information");
            var filename = sourcePath.Remove(0, sourcePath.LastIndexOf("\\", StringComparison.Ordinal) + 1);
            logging.WriteLog(String.Format("Filename - {0}", filename));
    
            var tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDir);
            var destPath = Path.Combine(tempDir, filename);
            logging.WriteLog(String.Format("Destination path - {0}", destPath));
            logging.WriteLog("Copying file from " + sourcePath + " to " + destPath);
            File.Copy(sourcePath, destPath, true);
    
            if (!File.Exists(destPath))
            {
                logging.WriteLog("File does not exist on the destination");
                logging.WriteLog("------------------------------------------------------------------------------------------");
                return "{'message':'File not copied', 'status':'404'}";
            }
    
            return "{'message':'OK', 'status':'200'}";
        }
        catch (Exception ex)
        {
            logging.WriteLog("Something went wrong while uploading " + ex);
            return "{'message':'error', 'status':'404'}";
        }
    }
