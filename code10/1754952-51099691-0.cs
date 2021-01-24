    public class LineImport
    {
        // Name these properties in a meaningful way for your task
        public bool Check {get;set;} 
        public string Text1 {get;set;}
        public string Text2 {get;set;}
        // The constructor receives the line and process it.
        public LineImport(string line)
        {
            // You can add some safety checks here to be sure the right format 
            // has been passed 
            string[] parts = line.Split(',');
            this.Text1 = parts[0];
            this.Text2 = parts[1];
        }
    }
