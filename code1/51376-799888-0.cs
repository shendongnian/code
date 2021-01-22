        public void ChangeProperties(string category, object value)
        {      
            var categoryConcat = category.Split('.');
            var control = this.Controls.Cast<Control>()
                .Where(x => x.Name == categoryConcat[0]).First();
            control.GetType().GetProperty(categoryConcat[1])
                .SetValue(control, value);        
        }
