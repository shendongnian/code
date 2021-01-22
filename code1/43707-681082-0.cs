    using System;
    using System.Data;
    using System.Windows.Forms;
    
    static class Program
    {
        [STAThread]
        static void Main()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Selected", typeof(bool));
            table.Rows.Add("Fred", false);
            table.Rows.Add("Jo", false);
            table.Rows.Add("Andy", true);
    
            Button btn = new Button();
            btn.Text = "Select all";
            btn.Dock = DockStyle.Bottom;
            btn.Click += delegate
            {
                foreach (DataRow row in table.Rows)
                {
                    row["Selected"] = true;
                }
            };
    
            DataGridView grid = new DataGridView();
            grid.Dock = DockStyle.Fill;
            grid.DataSource = table;
    
            Form form = new Form();
            form.Controls.Add(grid);
            form.Controls.Add(btn);
            Application.Run(form);
        }
    }
