          DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2]
            {
              new DataColumn("column1", typeof(int)),
              new DataColumn("column2", typeof(string))
            });
            
            dt.Clear();
            try
            {
                string input = string.Empty;
                input = Console.ReadLine();
                if (Regex.IsMatch(input, @"^[a-zA-Z]+$"))
                {
                    dt.Rows.Add(1, input);
                }
                Console.WriteLine(dt.Rows[0]["column2"]);
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
