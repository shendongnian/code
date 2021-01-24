        private static void SyncAndUpdateFileContent(string fileToSync)
        {
            if (!File.Exists(@"C:\Users\" + fileToSync))
            {
                throw new FileNotFoundException($"File {fileToSync} does not exist!");
            }
            var ori_Files11 = @"C:\Users\var\log\test.txt";
            List<Flds> ListDT11 = new List<Flds>();
            string fileHeader = null;
            using (StreamReader file11 = new StreamReader(ori_Files11))
            {
                string line;
                while ((line = file11.ReadLine()) != null)
                {
                    //Get file header copy
                    if (string.IsNullOrEmpty(fileHeader))
                    {
                        fileHeader = line;
                        continue;
                    }
                    string[] SpltStr11 = line.Split('|');
                    Flds DT11 = new Flds
                    {
                        Date = SpltStr11[0],
                        Name = SpltStr11[1],
                        TotalAcc = SpltStr11[2],
                        Folder = SpltStr11[3],
                        Done = SpltStr11[4]
                    };
                    ListDT11.Add(DT11);
                }
            }
            var stringBuilder = new StringBuilder($"{fileHeader}");
            foreach (var listDT11Item in ListDT11.Skip(1))
            {
                stringBuilder.AppendLine($"{listDT11Item.Date}|{listDT11Item.Name}|{listDT11Item.TotalAcc}|{listDT11Item.Folder}|{listDT11Item.TotalAcc}");
            }
            //Just call WriteAllText method at the end
            File.WriteAllText(ori_Files11, stringBuilder.ToString());
        }
    
    
