    public class Logging 
    { 
        private static readonly object locker = new object(); 
    
        public Logging() 
        { 
        } 
     
        public void WriteToLog(string message) 
        { 
            lock(locker) 
            { 
                StreamWriter sw; 
                sw = File.AppendText("Data\\Log.txt"); 
                sw.WriteLine(message); 
                sw.Close(); 
                sw.Dispose();
            } 
        } 
    } 
