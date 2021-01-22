            try
            {
                int[] a = { 3, 6 };
                Console.WriteLine(a[3]); //Throws index out of bounds exception
    
                System.IO.StreamReader sr = new System.IO.StreamReader(@"c:\does-not-exist"); // throws file not found exception
                throw new System.IO.IOException();
                
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
                Type t = ex.GetType();
    
                CultureInfo CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentUICulture;
    
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
    
                object o = Activator.CreateInstance(t);
    
                System.Threading.Thread.CurrentThread.CurrentUICulture = CurrentUICulture; // Changing the UICulture back to earlier culture
    
    
                Console.WriteLine(((Exception)o).Message.ToString());
                Console.ReadLine();
    
             }
