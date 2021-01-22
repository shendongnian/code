    public class EXMAPLE 
    {
        public event EventHandler Changed;
        protected string _content;
 
        public string Content{
            get { return _content; }
            set 
            {
                _content = value;
                OnChanged(EventArgs.Empty);
            }
        }
 
        // Invoke the Changed event; called whenever list changes:
        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }
    }
 
 
    class Program
    {
        private static void EXAMPLE_CONTENT_CHANGED(object sender, EventArgs e)
        {
            EXMAPLE ex = (EXMAPLE)sender;
            Console.WriteLine(ex.Content);
        }
 
        private static void INNA_REAKCJA(object sender, EventArgs e)
        {
            Console.WriteLine("The Content of EXAMPLE was changed");
        }
 
 
        static void Main(string[] args)
        {
            EXMAPLE ex1 = new EXMAPLE();
            EXMAPLE ex2 = new EXMAPLE();
 
            //add event ;->
            ex1.Changed += new EventHandler(EXAMPLE_CONTENT_CHANGED);
 
            ex2.Changed += new EventHandler(EXAMPLE_CONTENT_CHANGED);
            ex2.Changed += new EventHandler(INNA_REAKCJA);  
 
            //test
            ex1.Content = "value 1";
            ex2.Content = "value 2";
 
            System.Console.ReadKey();
        }
    }
