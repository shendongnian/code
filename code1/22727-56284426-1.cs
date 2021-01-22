    public string Exec(int count, int value)
    {
        int x = 0;
        Random random = new Random();
        Stopwatch time = new Stopwatch();
        time.Start();
        for (; x < count; x++)
        {
            switch (value)
            {
                case 0:
                    {
                        Pera obj5 = new Pera();
                        break;
                    }
                case 1:
                    {
                        Pera obj4 = new Pera();
                        break;
                    }
                case 2:
                    {
                        Banana obj3 = default(Banana);
                        break;
                    }
                case 3:
                    {
                        object obj2 = (random.Next(0, 1) == 0) ? new Fruta(new Manga()).GetInstance() : new Fruta(new Pera()).GetInstance();
                        break;
                    }
                default:
                    {
                        Banana obj = default(Banana);
                        break;
                    }
            }
        }
    time.Stop();
    return time.Elapsed.ToString();
    }
