    List<string> messagelst= new List<string>();
    private void WriteLog(string message)
    {
    
    
            messagelst.Add("New York");
            messagelst.Add("Mumbai");
            messagelst.Add("Berlin");
            messagelst.Add("Istanbul");
    if(messagelst.length==100){
    string message= string.Join(",", messagelst.ToArray());
    
        using (FileStream fs = new FileStream(@"C:\\RemoteDir\log.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Inheritable))
        using(StreamWriter sw = new StreamWriter(fs))
        {
            sw.WriteLine("#" + message);
        }
    
    messagelst= new List<string>();
    
    }
    }
