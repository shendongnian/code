    public class Logging 
    { 
        private readonly object locker = new object(); 
    
        public Logging() 
        { 
        } 
     
        public void WriteToLog(string message) 
        { 
            lock(locker) 
            { 
                StreamWriter SW; 
                SW=File.AppendText("Data\\Log.txt"); 
                SW.WriteLine(message); 
                SW.Close(); 
                SW.Dispose();
            } 
        } 
    } 
