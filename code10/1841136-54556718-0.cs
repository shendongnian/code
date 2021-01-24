    class Program
    {
        static void Main(string[] args)
        {
            // here, I'm just monitoring chrome, one of the sessions
            // if you want the whole speakers peak values, use AudioSession.GetSpeakersChannelsPeakValues()
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
 
