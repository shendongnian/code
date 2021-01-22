            string physicalFilePath = context.Request.PhysicalPath;
            string fileContent = string.Empty;
            // Determine whether file exists
            if (File.Exists(physicalFilePath))
            {
                // Read content from file
                using (StreamReader streamReader = File.OpenText(physicalFilePath))
                {
                    fileContent = streamReader.ReadToEnd();
                }
            }
            context.Response.Output.Write(convertedFile);
            context.Response.Flush();
