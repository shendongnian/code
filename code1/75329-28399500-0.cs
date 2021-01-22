            e.Handled = !(char.IsLetter(e.KeyChar));
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = !(char.IsControl(e.KeyChar));
            }
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = !(char.IsWhiteSpace(e.KeyChar));
            }
        }
