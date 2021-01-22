    static void Main(string[] args)
    {
       System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
       sw.Start();
       const int count = 1000000;
       float[] results = new float[count];
       for (int i = 0; i < count; i++)
       {
          results[i] = AbsPulse(i/1000000F);
          //results[i] = SinPulse(i / 1000000F);
       }
       sw.Stop();
       Console.WriteLine("Time Elapsed: {0} seconds", sw.Elapsed.TotalSeconds);
       char[,] graph = new char[80, 20];
       for (int y = 0; y <= graph.GetUpperBound(1); y++)
          for (int x = 0; x <= graph.GetUpperBound(0); x++)
             graph[x, y] = ' ';
       for (int x = 0; x < count; x++)
       {
          int col = x * 80 / count;
          graph[col, (int)(results[x] * graph.GetUpperBound(1))] = 'o';
       }
       for (int y = 0; y <= graph.GetUpperBound(1); y++)
       {
          for (int x = 0; x < graph.GetUpperBound(0); x++)
             Console.Write(graph[x, y]);
          Console.WriteLine();
       }
    }
    static float AbsPulse(float time)
    {
       const int frequency = 10; // Frequency in Hz
       const int resolution = 1000; // How many steps are there between 0 and 1
       return Math.Abs(resolution - ((int)(time * frequency * 2 * resolution) % (resolution * 2))) / (float)resolution;
    }
    static float SinPulse(float time)
    {
       const float pi = 3.14F;
       const float frequency = 10; // Frequency in Hz
       return 0.5F * (1 + (float)Math.Sin(2 * pi * frequency * time));
    }
