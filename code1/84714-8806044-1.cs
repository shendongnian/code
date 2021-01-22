    private void TryCatchPerformance()
        {
            int iterations = 10000;
            textBox1.Text = "";
            Stopwatch stopwatch = Stopwatch.StartNew();
            int c = 0;
            for (int i = 0; i < iterations; i++)
            {
                try
                {   
                    c += i / (i % 50);
                }
                catch (Exception)
                {
                    
                }
            }
            stopwatch.Stop();
            Debug.WriteLine(String.Format("With try catch: {0}", stopwatch.Elapsed.TotalSeconds));
            Stopwatch stopwatch2 = Stopwatch.StartNew();
            int c2 = 0;
            for (int i = 0; i < iterations; i++)
            {
                int iMod50 = (i%50);
                if(iMod50 > 0)
                    c2 += i / iMod50;
            }
            stopwatch2.Stop();
            Debug.WriteLine( String.Format("Without try catch: {0}", stopwatch2.Elapsed.TotalSeconds));
        }
