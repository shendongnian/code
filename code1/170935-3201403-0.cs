        public Control GenerateCombo() 
        { 
            // Create datasource 
            Collection<Car> cars = new Collection<Car>(); 
            Car c = new Car(); 
            c.Id = 1; 
            c.Name = "Car one"; 
            cars.Add(c); 
 
            Car c1 = new Car(); 
            c1.Id = 2; 
            c1.Name = "Car two"; 
            cars.Add(c1); 
 
            Car c2 = new Car(); 
            c2.Id = 2; 
            c2.Name = "Car three"; 
            cars.Add(c2); 
 
            ComboBox cmb = new ComboBox(); 
            cmb.DropDownStyle = ComboBoxStyle.DropDownList; 
            cmb.DataSource = cars; 
            cmb.DisplayMember = "Name"; 
            cmb.ValueMember = "Id"; 
            // add this: 
            EventHandler visibleChangedHandler = null; 
            visibleChangedHandler = delegate { 
                cmb.SelectedIndex = 2; 
                cmb.VisibleChanged -= visibleChangedHandler;
            }; 
            cmb.VisibleChanged += visibleChangedHandler; 
            // delete this: cmb.SelectedValue = 2; 
 
            return cmb; 
        } 
