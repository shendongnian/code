    Process[] Edge = Process.GetProcessesByName("MicrosoftEdge");
                foreach (Process Item in Edge)
                {
                    try
                    {
                        Item.Kill();
                        Item.WaitForExit(3000);
                    }
                    catch (Exception)
                    {
                    }
                }
