     string[] dataSource = new string[30];
            for(int i = 0; i < 30; i++)
            {
                dataSource[i] = "test " + i.ToString();                
            }
            ComboBox cb = new ComboBox();
            cb.Size = new Size(121, 21);
            cb.Location = new Point(55, 74);
            BindingSource bS = new BindingSource();
            cb.BindingContext = new BindingContext();            
            bS.DataSource = dataSource;
            cb.DataSource = bS.DataSource;           
            
            
            cb.SelectedIndex = 4;// shoul and does display test 3
            this.Controls.Add(cb);
