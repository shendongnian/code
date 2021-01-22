    ManagementObject cs;
            using(cs = new ManagementObject("Win32_ComputerSystem.Name='" + System.Environment.MachineName + "'" ))
            {
                cs.Get();
                Console.WriteLine("{0}",cs["domain"].ToString());
            }
