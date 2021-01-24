     static void Main(string[] args)
            {
                System.Media.SoundPlayer s1 = new System.Media.SoundPlayer(@"c:\Users\Ben\Documents\c#\note_c.wav");
                s1.Load();
    
                System.Media.SoundPlayer s2 = new System.Media.SoundPlayer(@"c:\Users\Ben\Documents\c#\note_e.wav");
                s2.Load();
    
                Console.WriteLine("Hello World");
                Thread th = new Thread(() => playSound(s1));
                Thread th1 = new Thread(() => playSound(s2));
    
                th.Start();
                th1.Start();
            }
    
            public static void playSound(System.Media.SoundPlayer s)
            {
                s.PlaySync();
            }
