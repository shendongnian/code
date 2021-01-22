            if (!(Char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
           
            else
                e.Handled = false;
        }
