            for (int i = 0; i < 100; i++)
            {
                System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
                string s = "dsfasdfsdafasd";
                timer.Start();
                if (s.Length > 0)
                {
                }
                timer.Stop();
                System.Diagnostics.Debug.Write(String.Format("s.Length != 0 {0} ticks       ", timer.ElapsedTicks));
                timer.Reset();
                timer.Start();
                if (s == String.Empty)
                {
                }
                timer.Stop();
                System.Diagnostics.Debug.WriteLine(String.Format("s== String.Empty {0} ticks", timer.ElapsedTicks));
            }
