        void PreviewTextInputHandler(object sender, TextCompositionEventArgs e)
        {
            string sVal = e.Text;
            int val = 0;
            if (sVal != null && sVal.Length > 0)
            {
                if (int.TryParse(sVal, out val))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
