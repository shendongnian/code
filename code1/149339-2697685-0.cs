    namespace ExtensionMethods
    {
        public static class MyExtensions
        {
            public static bool IsTextEmpty(this Textbox txtBox)
            {
                return string.IsNullOrEmpty(txtBox.Text);
            }
        }   
    }
