            public int Num { get; set; }
            public string Start { get; set; }
            public string Finich { get; set; }
        }
        private void generate_columns()
        {
            DataGridTextColumn c1 = new DataGridTextColumn();
            c1.Header = "Num";
            c1.Binding = new Binding("Num");
            c1.Width = 110;
            dataGrid1.Columns.Add(c1);
            DataGridTextColumn c2 = new DataGridTextColumn();
            c2.Header = "Start";
            c2.Width = 110;
            c2.Binding = new Binding("Start");
            dataGrid1.Columns.Add(c2);
            DataGridTextColumn c3 = new DataGridTextColumn();
            c3.Header = "Finich";
            c3.Width = 110;
            c3.Binding = new Binding("Finich");
            dataGrid1.Columns.Add(c3);
            dataGrid1.Items.Add(new Item() { Num = 1, Start = "2012, 8, 15", Finich = "2012, 9, 15" });
            dataGrid1.Items.Add(new Item() { Num = 2, Start = "2012, 12, 15", Finich = "2013, 2, 1" });
            dataGrid1.Items.Add(new Item() { Num = 3, Start = "2012, 8, 1", Finich = "2012, 11, 15" });
        }
