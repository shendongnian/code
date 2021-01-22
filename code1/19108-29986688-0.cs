    string concat = "";
            System.Diagnostics.Stopwatch sw1 = new System.Diagnostics.Stopwatch    ();
            sw1.Start();
            for (int i = 0; i < 10000000; i++)
            {
                concat = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}","1", "2" , "3" , "4" , "5" , "6" , "7" , "8" , "9" , "10" , i);
            }
            sw1.Stop();
            Response.Write("format: "  + sw1.ElapsedMilliseconds.ToString());
            System.Diagnostics.Stopwatch sw2 = new System.Diagnostics.Stopwatch();
            sw2.Start();
            for (int i = 0; i < 10000000; i++)
            {
                concat = "1" + "2" + "3" + "4" + "5" + "6" + "7" + "8" + "9" + "10" + i;
            }
            sw2.Stop();
