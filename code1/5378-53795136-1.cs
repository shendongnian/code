    using System;
    using System.Text;
    
    namespace StringVsStrigBuilder
    {
        class Program
        {
            static void Main(string[] args)
            {
                // StringBuilder Example
    
                StringBuilder name = new StringBuilder();
                name.Append("Rehan");
                name.Append("Shah");
                name.Append("RS");
                name.Append("---");
                name.Append("I love to write programs.");
    
    
                // Now when I run this program this output will be look like this.
                // output : "Rehan Shah Rs --- I love to write programs."
            }
        }
    }
