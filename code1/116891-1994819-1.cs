            using(Form form = new Form())
            using (PropertyGrid grid = new PropertyGrid())
            {
                form.Text = obj.ToString(); // why not...
                grid.Dock = DockStyle.Fill;
                form.Controls.Add(grid);
                grid.SelectedObject = obj;
                form.ShowDialog(this);
            }
