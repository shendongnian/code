    using System.Data;
    using System.Windows.Forms;
    static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            DataTable table = new DataTable
            {
                Columns = {
                    {"Foo", typeof(double)},
                    {"Bar", typeof(string)}
                },
                Rows = {
                    {123.45, "abc"},
                    {678.90, "def"}
                }
            };
            Form form = new Form();
            DataGridView grid = new DataGridView {
                Dock = DockStyle.Fill, DataSource = table};
            form.Controls.Add(grid);
            grid.CurrentCellChanged += delegate
            {
                form.Text = string.Format("{0}: {1}",
                    grid.CurrentCell.Value.GetType(),
                    grid.CurrentCell.Value);
    
                if (grid.CurrentCell.Value is double)
                {
                    double val = (double)grid.CurrentCell.Value;
                    form.Text += " is a double: " + val;
                }
            };
            Application.Run(form);
    
        }
    }
