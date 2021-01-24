    helper.ReadMessageEvent += ReadMessageEvent_HandleEvent;
     private void ReadMessageEvent_HandleEvent(object sender, EventArgs e)
     {
       string message = sender as string;
       Console.WriteLine(message);           
     }
