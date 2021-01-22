    public static class ControlHelper
    {
        public static Populate<T>(this ComboBox comboBox, IEnumerable<T> items)
        {
            try
            {
                comboBox.BeginUpdate();
                foreach (T item in items)
                {
                    comboBox.Items.Add(item);
                }
            }
            finally
            {
                comboBox.EndUpdate();
            }
        }
    }
