        private void getAll()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Active", typeof(bool));
            table.Columns.Add("ActiveStatus", typeof(Image));
            
            String yesPath = @"C:\temp\Yes.png";
            String noPath = @"C:\temp\No.png";
            // Here we add five DataRows. You can add condition here to set appropriate image path.
            table.Rows.Add(25, "Indocin", "David", true,Image.FromFile(yesPath));
            table.Rows.Add(50, "Enebrel", "Avil", false, Image.FromFile(noPath));
            table.Rows.Add(10, "Hydralazine", "Christoff", false, Image.FromFile(noPath));
            table.Rows.Add(21, "Combivent", "Janet", false, Image.FromFile(noPath));
            table.Rows.Add(100, "Dilantin", "Melanie", false, Image.FromFile(noPath));
            dataGridView1.DataSource = table;
        }
