    public static class CheckBoxExtensions
    {
        public static string IsChecked(this CheckBox checkBox)
        {
            return checkBox.Checked ? "Yes" : "No";
        }
    }
