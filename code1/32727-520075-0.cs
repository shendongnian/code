    using System;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
    
            DataSet set = new DataSet();
            DataTable table = set.Tables.Add("MyTable");
            table.Columns.Add("Foo", typeof(int));
            table.Columns.Add("Bar", typeof(string));
    
            Button btn;
            using (Form form = new Form
            {
                Text = "DataGridView binding sample",
                Controls =
                {
                    new DataGridView {
                        Dock = DockStyle.Fill,
                        DataMember = "MyTable",
                        DataSource = set
                    },
                    (btn = new Button {
                        Dock = DockStyle.Bottom,
                        Text = "Total"
                    })
                }
            })
            {
                btn.Click += delegate
                {
                    form.Text = table.AsEnumerable().Sum(
                        row => row.Field<int>("Foo")).ToString();
                };
                Application.Run(form);
            }
    
        }
    }
