            string destination = @"C:\Some\Destination\";
            string actualFile = string.Empty;
            foreach (var file in fileList)
            {
                actualFile = file.FullName;
                File.Copy(actualFile, destination + Path.GetFileName(actualFile));
            }
