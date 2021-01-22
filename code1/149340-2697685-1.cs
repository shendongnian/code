    namespace ExtensionMethods
    {
        public static class MyExtensions
        {
            public static bool IsTextEmpty(this MyTextbox txtBox)
            {
                return string.IsNullOrEmpty(txtBox.Text);
            }
        }   
    }
