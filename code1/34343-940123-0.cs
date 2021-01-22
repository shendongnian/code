            get
            {
                return base.SelectedItem;
            }
            set
            {
                base.SelectedItem = value;
                if (value == null || value == System.DBNull.Value)
                {
                    this.SelectedIndex = -1;
                }
                **foreach (Binding binding in DataBindings)
                {
                    if (binding.PropertyName == "SelectedItem")
                    {
                        binding.WriteValue();
                    }
                }**
            }
        }
