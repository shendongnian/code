            if (IsDesignTime)
                return;
            brw.IsSelected = true;    
            if (tbc.Visibility != Visibility.Visible)
            {
                tbc.Visibility = Visibility.Visible;
            }
            else
            {
                tbc.Visibility = Visibility.Collapsed;
            }
        }
