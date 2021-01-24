    using (var query = new ManagementObjectSearcher("SELECT AllocatedBaseSize FROM Win32_PageFileUsage"))
            {
                foreach (ManagementBaseObject obj in query.Get())
                {
                    uint used = (uint)obj.GetPropertyValue("AllocatedBaseSize");
                    Console.WriteLine(used);
                }
            }
