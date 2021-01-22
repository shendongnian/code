        private bool decimalSeparator = false;
        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Decimal)
                decimalSeparator = true;
        }
        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (decimalSeparator)
            {
                e.KeyChar = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
                decimalSeparator = false;
            }
        }
