    public Client MasterMenuItem
        {
            get {
                Client Property = GetValue(MasterMenuItemProperty) as Client;
                if (Property != null)
                    LoadAddresses(Property.Id);
                return Property as Client;
            }
            set { SetValue(MasterMenuItemProperty, value); }                
        }
