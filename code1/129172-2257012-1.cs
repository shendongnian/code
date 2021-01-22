        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            BindingList<YourClass> list = new BindingList<YourClass>();
            DataGridView grid = new DataGridView();
            grid.Dock = DockStyle.Fill;
            grid.DataSource = list;
            Button add = new Button();
            add.Text = "Add";
            add.Dock = DockStyle.Bottom;
            add.Click += delegate
            {
                YourClass newObj = new YourClass();
                newObj.Message = DateTime.Now.ToShortTimeString();
                list.Add(newObj);
            };
            Button edit = new Button();
            edit.Text = "Edit";
            edit.Dock = DockStyle.Bottom;
            edit.Click += delegate
            {
                if (list.Count > 0)
                {
                    list[0].Message = "Boo!";
                    list[0].IsRead = !list[0].IsRead;
                }
            };
            Form form = new Form();
            form.Controls.Add(grid);
            form.Controls.Add(add);
            form.Controls.Add(edit);
            Application.Run(form);
        }
