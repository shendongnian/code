        private void Navigate (Type viewType)
        {
            Window win;
            if (Views.ContainsKey(viewType))
            {
                win = Views[viewType];
            }
            else
            {
                win = (UserControl)Activator.CreateInstance(viewType);
                Views[viewType] = win;
            }
            win.Show();
        }
        private Dictionary<Type, Window> Views = new Dictionary<Type, Window>();
    }
