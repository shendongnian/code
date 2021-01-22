            string outPutFile = @"C:\Output.txt";
            string result = "Some new string" + DateTime.Now.ToString() + Environment.NewLine;
            StringBuilder currentContent = new StringBuilder();
            List<string> rawList = File.ReadAllLines(outPutFile).ToList();
            foreach (var item in rawList)
            {
                currentContent.Append(item + Environment.NewLine);
            }            
            File.WriteAllText(outPutFile, result + currentContent.ToString());  
