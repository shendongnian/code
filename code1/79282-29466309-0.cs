    namespace System.Window.Form
    {
        public static class Ext
        {
            public static DialogResult ShowDialog(this UserControl @this, string title)
            {
                Window wind = new Window() { Title = title, Content = @this };
                return wind.ShowDialog();
            }
        }
    }
