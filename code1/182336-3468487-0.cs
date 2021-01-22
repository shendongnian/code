    public class Window1 : Window
    {
        ...
    
        private void btnPromptFoo_Click(object sender, RoutedEventArgs e)
        {
            var w = new Window2();
            if (w.ShowDialog() == true)
            {
                string foo = w.Foo;
                ...
            }
        }
    }
    
    public class Window2 : Window
    {
        ...
    
        public string Foo
        {
            get { return txtFoo.Text; }
        }
    
    }
