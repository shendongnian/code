            string content;
            var filePath = "e:\\test.txt";
            //Lock Exclusively the file
            var r = File.Open(filePath, FileMode.Open, FileAccess.Write, FileShare.Write);
            //CaffGeek solution
            using (FileStream fileStream = new FileStream(
            filePath,
            FileMode.Open,
            FileAccess.Read,
            FileShare.ReadWrite))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    content = streamReader.ReadToEnd();
                }
            }
