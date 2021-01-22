    public class ThreadParameter
            {
                public int Port { get; set; }
                public string Path { get; set; }
            }
    Thread t = new Thread(new ParameterizedThreadStart(Startup));
    t.Start(new ThreadParameter() { Port = port, Path = path});
