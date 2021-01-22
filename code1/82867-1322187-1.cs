    private void NuestroButton1_Click(object sender, RoutedEventArgs e)
    {
       Button foo = sender as Button; // Cast to the type we're expecting it to be
       if( foo != null && foo.Content == "X" )
       {
            //Do something
            System.Windows.Browser.HtmlPage.Window.Alert("Hello World");
       }
    }
