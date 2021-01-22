    static class Program
    {    
       [STAThread]
       static void Main(string[] args)
       {            
           Application.EnableVisualStyles();
           Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new Form1(args[0], Convert.ToInt32(args[1])));           
       }
    }
