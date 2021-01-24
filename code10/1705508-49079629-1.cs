    if (e.PartialResult.ToLower().Contains(x))
    {
         string lastLine = File.ReadLines(pathToTextFile).Last();
         if(string.Format("{0:00}:{1:00}:{2:00} Found keyword here", ts.Hours, ts.Minutes, ts.Seconds) != lastLine)
         {
              using (StreamWriter sw = File.AppendText(string.Format(textBox1.Text + @"\SpyTrouble Logs\Keywords {0} {1}-{2}.txt", Environment.UserName, now.Day, now.Month)))
              {
                  string elapsedTime = string.Format("{0:00}:{1:00}:{2:00} Found keyword here", ts.Hours, ts.Minutes, ts.Seconds);
                  sw.WriteLine(elapsedTime);
              }
         }                     
    }
