    using System;
    using Microsoft.SqlServer.Management.Smo;
    using System.Data;
    using System.Windows.Forms;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                DataTable dt = SmoApplication.EnumAvailableSqlServers(true);
                Server sr = new Server("MACHINE_NAME\\INSTANCE_NAME");
    
                try
                {
                    foreach (Database db in sr.Databases)
                    {
                        Console.WriteLine(db.Name);
                    }
                    Console.Read();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.ToString());
                }
            }
        }
    }
