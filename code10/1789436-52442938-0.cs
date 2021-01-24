            foreach (string emotion in emotions)
            {
                var lines = File.ReadAllLines("C:\\Users\\Griffin\\Documents\\C#\\thavma\\thavma\\bin\\Debug\\libraries\\" + emotion + ".lib");
                emotiondict.Add(emotion, lines);
                foreach (string f in lines)
                {
                    Console.WriteLine(f);
                }
            }
            Console.ReadLine();
