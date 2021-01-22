    static void Main() {
        TextBox tb = new TextBox();
        tb.KeyPress += (s, a) =>
        {
            string txt = tb.Text;
            if (char.IsLetterOrDigit(a.KeyChar)
                && txt.Length > 0 &&
                a.KeyChar <= txt[txt.Length-1])
            {
                a.Handled = true;
            }
        };
        Form form = new Form();
        form.Controls.Add(tb);
        Application.Run(form);
    }
