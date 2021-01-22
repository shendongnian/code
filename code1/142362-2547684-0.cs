    memScan = new Thread(ScanMem);
    public static void ScanMem()
        {            
            int i = addy.Length;
            while (true)
            {
                for (int j = 0; j < i; j++)
                {
                    Thread.Sleep(10000); // Reduce sleep
                    string[] values = addy[j].Split(new char[] { Convert.ToChar(",") });
                    //MessageBox.Show(values[2]);
                    try
                    {
                        if (Memory.Scanner.getIntFromMem(hwnd, (IntPtr)Convert.ToInt32(values[0], 16), 32).ToString() != values[1].ToString())
                        {
                            //Ok, it changed lets do our work
                            //work 
                            if (Globals.Working)
                                return;                            
                            SomeFunction("Results: " + values[2].ToString(), "Memory");
                            Globals.Working = true;
                        }//end if
                    }//end try
                    catch { }
                }//end for
            }//end while
        }//end void
