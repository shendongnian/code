     private string logFilePath = "C:\\SetupLog.txt";    
     public void Log(string str)
        {
            StreamWriter Tex;
            try
            {
                Tex = File.AppendText(this.logFilePath);
                Tex.WriteLine(DateTime.Now.ToString() + " " + str);
                Tex.Close();
            }
            catch
            { }
        }
