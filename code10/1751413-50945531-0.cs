            var keyWord = "companyName";
            var hasKeyword = false;
            foreach (var line in System.IO.File.ReadAllLines(filePath))
            {
                if (line.Contains(keyWord))
                {
                    Console.WriteLine(line);
                    hasKeyword = true;
                }
                if (hasKeyword)
                {
                    Console.WriteLine(line);
                    hasKeyword = false;
                }
            } 
