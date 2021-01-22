                    using (var mos = new ManagementObjectSearcher(
                        "SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + pid))
                    {
                        foreach (var obj in mos.Get())
                        {
                            object data = obj.Properties["CommandLine"].Value;
                            if (data != null)
                            {
                                Console.WriteLine("{0}: commandline = {1}", pid, data.ToString());
                            }
                        }
                    }
                }
            }
