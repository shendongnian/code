           //declare this somewhere
           TimeSpan? lastWrite = null;
            foreach (string x in keywords)
            {
                if (e.PartialResult.ToLower().Contains(x))
                {
                    if (!TimeSpan.Equals(lastWrite, ts) || lastWrite == null )
                    {
                        using (StreamWriter sw = File.AppendText(string.Format(textBox1.Text + @"\SpyTrouble Logs\Keywords {0} {1}-{2}.txt", Environment.UserName, now.Day, now.Month)))
                        {
                            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00} Found keyword here", ts.Hours, ts.Minutes, ts.Seconds);
                            lastWrite = ts;
                            sw.WriteLine(elapsedTime);
                        }
                    }
                }
            }
