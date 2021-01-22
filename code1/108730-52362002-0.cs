       private static void Main()
        {
            AppDomain.CurrentDomain.FirstChanceException += (s, e) =>
            {
                var frames = new StackTrace().GetFrames();
                Console.Write($"{frames.Length - 2} ");
                var frame = frames[101];
            };
            throw new Exception();
        }
