    class Program
    {
        static void Main(string[] args)
        {
            // Here, I'm just monitoring chrome, one of the possible sessions.
            // If you want the whole speakers peak values, use the AudioSession.GetSpeakersChannelsPeakValues() method
            foreach (var session in AudioSession.EnumerateAll())
            {
                if (session.Process?.ProcessName == "chrome")
                {
                    do
                    {
                        var values = session.GetChannelsPeakValues();
                        if (values.Length == 0)
                            continue;
                        Console.WriteLine(string.Join(" ", values.Select(v => v.ToString("00%"))));
                    }
                    while (true);
                }
                session.Dispose();
            }
        }
    }
 
