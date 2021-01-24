    internal static class FormUtils
    {
        internal static void ClearAllTextBoxes(Form form)
        {
            if (form == null)
                return;
            if (form.Controls.Count <= 0)
                return;
            foreach (var box in form.Controls.OfType<TextBox>())
            {
                box.Clear();
            }
        }
    }
