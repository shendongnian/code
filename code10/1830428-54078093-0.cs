            var rows = System.IO.File.ReadAllLines(@"C:\temp\ks1.txt");
            string[,] d2A = new string[rows.Length, 2];
            for (int i = 0; i < rows.Length; i++)
            {
                var row = rows[i].Split(new string[] { " - " }, StringSplitOptions.None);
                d2A[i, 0] = row[0];
                d2A[i, 1] = row[1];
            }
