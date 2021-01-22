    private void timer_Callback(object state, EventArgs eventArgs) 
    {
        Dispatcher.Invoke(new System.Threading.ThreadStart(delegate()
        {
            current_clip_board.Content = Clipboard.GetText(); 
        }
    } 
