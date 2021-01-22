    public class FormCleaner // this is FormCleaner.cs
    {
        // 'generic' form cleaner
        public void ClearForm(Form form)
        {
            foreach(Control control on form.Controls)
            {
                // this will probably not work ok, because also
                // static controls like Labels will have their text removed.
                control.Text = "";
            }
        }
    }
