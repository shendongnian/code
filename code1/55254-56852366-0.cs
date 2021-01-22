    var table = new Table();
            table.SetHeaders("Name", "Date", "Number");
            for (int i = 0; i <= 10; i++)
            {
                if (i % 2 == 0)
                    table.AddRow($"name {i}", DateTime.Now.AddDays(-i).ToLongDateString(), i.ToString());
                else
                    table.AddRow($"long name {i}", DateTime.Now.AddDays(-i).ToLongDateString(), (i * 5000).ToString());
            }
            Console.WriteLine(table.ToString());
