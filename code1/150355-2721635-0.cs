    // static class...
    public static class ComboBoxHelper
    {
        public static string GetSelectedIndexText(this ComboBox target)
        {
            return target.Items[target.SelectedIndex].ToString();
        }
        
        public static object[] GetNonSelectedItems(this ComboBox target)
        {
            string selected = GetSelectedIndexText(target);
            
            try
            {
                object[] result = 
                  target.Items.Cast<object>().Where(c => c.ToString() 
                  != selected).ToArray();
                return result;
            }
            catch
            {
                return new object[] { };
            }
        }
    
        public static void ReplaceItems(this ComboBox target, object[] newRange)
        {
            target.Items.Clear();
            target.Items.AddRange(newRange);
        }
    }
