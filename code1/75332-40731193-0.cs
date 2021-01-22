    private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!(char.IsLetter(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && !(char.IsControl(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)))
                {
                    e.Handled = true;
                }
            }
