            string[] names = { "Fred", "Barney", "Betty", "Wilma" };
            using (Form form = new Form())
            {
                foreach (string name in names)
                {
                    Button btn = new Button();
                    btn.Text = name;
                    btn.Click += delegate
                    {
                        MessageBox.Show(form, name);
                    };
                    btn.Dock = DockStyle.Top;
                    form.Controls.Add(btn);
                }
                Application.Run(form);
            }
