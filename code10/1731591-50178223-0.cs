    public Event EventHandler MyEvent;
    ///raise the event
    private void btn_Click(object sender, RoutedEventArgs e)
    {
     MyEvent(this , e);
    }
  
