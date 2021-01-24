     using System.Drawing.Printing;
    
     public class PrintingExample 
     {
        private void pd_PrintPage(object sender, PrintPageEventArgs ev) 
        {
            MessageBox.Show("Printing");
        }
    
        public static void Main(string[] args) 
        {
           PrintDocument pd = new PrintDocument(); 
           pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
           //Print the document.
           pd.Print(); 
        }
     }
