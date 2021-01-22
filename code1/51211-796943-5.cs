    public class MyEventArgs : EventArgs
    {
        public string SomeData
        { get; 
          private set;
        }
       
        public MyEventArgs( string s ) 
        {
            this.SomeData = s;
        }
    }
