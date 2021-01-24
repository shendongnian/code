    void Awake()
    {
        UnityThread.initUnityThread();
    }
    public static void ThreadedFileRead(string path, Action<float> percAction, Action<string> finishedReading)
    {
        /* Replace Task.Factory with ThreadPool when using .NET <= 3.5
         * 
         * ThreadPool.QueueUserWorkItem(state =>
         * 
         * */
        var task = Task.Factory.StartNew(() =>
        {
            FileInfo fileInfo = new FileInfo(path);
            StringBuilder sb = new StringBuilder();
            float length = fileInfo.Length;
            int currentLength = 0;
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    sb.AppendLine(str);
                    // yield return str;
                    //Call on main Thread
                    UnityThread.executeInUpdate(() =>
                     {
                         percAction(currentLength / length);
                     });
                    currentLength += str.Length;
                    //Interlocked.Add(ref currentLength, str.Length);
                }
                //Call on main Thread
                UnityThread.executeInUpdate(() =>
                 {
                     finishedReading(sb.ToString());
                 });
            }
        });
    }
