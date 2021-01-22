    static class ControlHelper
    {
        public static void SelectExactMatch(this ComboBox c, string find)
        {
            c.SelectedIndex = c.FindStringExact(find, 0);
        }
    }
