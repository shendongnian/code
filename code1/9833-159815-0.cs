    public static class ComboBoxExtensions
    {
        public static bool ContainsKey(this ComboBox comboBox, string key)
        {
            foreach (string existing in comboBox.Items)
            {
                if (string.Equals(key, existing))
                {
                    return true;
                }
            }
            return false;
        }
    }
