    using System;
    using System.Text;
    using System.Windows.Media;
    using System.Windows;
    
    namespace ConsoleApplication2
    {
      class Program
      {
        static void Main(string[] args)
        {
          if (args.Length == 0)
            return;
          Console.Write(args[0] + ": ");
          MediaPlayer player = new MediaPlayer();
          Uri path = new Uri(args[0]);
          player.Open(path);
          TimeSpan maxWaitTime = TimeSpan.FromSeconds(10);
          DateTime end = DateTime.Now + maxWaitTime;
          while (DateTime.Now < end)
          {
            System.Threading.Thread.Sleep(100);
            Duration duration = player.NaturalDuration;
            if (duration.HasTimeSpan)
            {
              Console.WriteLine(duration.TimeSpan.ToString());
              break;
            }
          }
          player.Close();
        }
      }
    }
