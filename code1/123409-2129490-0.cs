    static class Program 
    { 
        [STAThread] 
        static void Main() 
        { 
            Application.EnableVisualStyles(); 
            Application.SetCompatibleTextRenderingDefault(false); 
     
            DialogResult rc;
            do
            {
                using (Login login = new Login()) 
                { 
                   rc = login.ShowDialog(); 
                   if (rc == DialogResult.OK) 
                   { 
                      Application.Run(new Form1()); 
                   }  
                } 
             }
             while (rc == DialogResult.Retry) 
         }
     }
