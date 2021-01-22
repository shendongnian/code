        private void numeroCuenta_TextChanged(object sender, EventArgs e)
        {
            string org = numeroCuenta.Text;
            string formated = string.Concat(org.Where(c => (c >= '0' && c <= '9')));
            if (formated != org)
            {
                int s = numeroCuenta.SelectionStart;
                if (s > 0 && formated.Length > s && org[s - 1] != formated[s - 1]) s--;
                numeroCuenta.Text = formated;
                numeroCuenta.SelectionStart = s;
            }
        }
