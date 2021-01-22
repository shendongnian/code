    public class Logging
    {
        public Logging()
        {
        }
    
        private static readonly object locker = new object();
    
        public void WriteToLog(string message)
        {
            lock(locker)
            {
                StreamWriter SW;
                SW=File.AppendText("Data\\Log.txt");
                SW.WriteLine(message);
                SW.Close();
            }
        }
    }
