            string pathWithSqlFiles = @"c:\sqlfiles\";
            string[] files = System.IO.Directory.GetFiles(pathWithSqlFiles, "*.sql", System.IO.SearchOption.AllDirectories);
            string regexToSearch = @"\[?admin\]?.\[?table\]?";
            foreach (string file in files)
            {
                string fileText = System.IO.File.ReadAllText(file);
                System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(fileText, regexToSearch, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    // do logic to handle the matched text
                }
            }
