            public event EventHandler ValueSelected;
            
            protected virtual void OnValueSelected(ValueSelectedEventArgs e)
            {
                EventHandler handler = ValueSelected;
                if (handler != null)
                {
                    handler(this, e);
                }
    
                // if you are using recent version of c# you can simplyfy the code to ValueSelected?.Invoke(this, e);     
            }
