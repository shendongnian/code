    public class MyPage : Page
    {
        public MyPage() : base()
        {
             this.Load += (sender,e) => {
                 // bleugh - subscribing to my own events 
             }
        }
    }
