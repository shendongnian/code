    using System;
    
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Starting WpfApplication1.exe...");
            
            var domain = AppDomain.CreateDomain("WpfApplication1Domain");
            try
            {
                domain.ExecuteAssembly("WpfApplication1.exe");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                AppDomain.Unload(domain);
            }
            
            Console.WriteLine("WpfApplication1.exe exited, exiting now.");
        }
    }
