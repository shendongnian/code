    public class myCustomeEventArgs:EventArgs
    {
        public bool DoOverride { get; set; }
        public string Variable1 { get; private set; }
        public string Variable2{ get; private set; }
        public myCustomeEventArgs(string variable1 , string variable2 )
        {
            DoOverride = false;
            Variable1 = variable1 ;
            Variables = variable2 ;
        }
    }
