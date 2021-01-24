    public static class MyExtensions
    {
        public static TextBox setWidth(this TextBox txtBox, Int16 width)
        {
            txtBox.Width = width;
            return txtBox;
        }
        public static TextBox setHeight(this TextBox txtBox, Int16 height)
        {
          //txtBox.Multiline = true; //uncomment this property in order to make the height property work
            txtBox.Height = height;
            return txtBox;
        }
        public static TextBox setText(this TextBox txtBox, string text)
        {
            txtBox.Text = text;
            return txtBox;
        }
    }   
