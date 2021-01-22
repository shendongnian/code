        public static Binding Bind<TObject>(this RadioButton control, object dataSource, string dataMember)
        {
            // Put the radio button into its own panel
            Panel panel = new Panel();
            control.Parent.Controls.Add(panel);
            panel.Location = control.Location;
            panel.Size = control.Size;
            panel.Controls.Add(control);
            control.Location = new Point(0, 0);
            // Do the actual data binding
            return control.DataBindings.Add("Checked", dataSource, dataMember);
        }
