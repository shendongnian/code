	class Program
	{
        static Dictionary<object, Stopwatch> stopwatchesByObject;
        static void Main(string[] args)
		{
            List<object> objects = new List<object>();
            // now you have to fill the objects list...
            stopwatchesByObject = new Dictionary<object, Stopwatch>();
            foreach (var o in objects)
            {
                stopwatchesByObject.Add(o, new Stopwatch());
            }
        }
        // Call this method when the user starts gazing at object o
        static void StartGazingAt(object o)
        {
            stopwatchesByObject[o].Start();
        }
        // Call this method when the user stops gazing at object o
        static void StopGazingAt(object o)
        {
            stopwatchesByObject[o].Stop();
        }
        static void CreateStatistics()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var entry in stopwatchesByObject)
            {
                sb.AppendLine($"Gazed at {entry.Key.ToString()} for {entry.Value.Elapsed.TotalSeconds} seconds.");
            }
            File.WriteAllText("c:\\temp\\statictics.txt", sb.ToString());
        }
    }
