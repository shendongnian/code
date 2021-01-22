    public class Fruta
    {
        dynamic _instance;
        public Fruta(dynamic obj)
        {
            _instance = obj;
        }
        public dynamic GetInstance()
        {
            return _instance;
        }
    }
    public class Manga
    {
        public int MyProperty { get; set; }
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
        public int MyProperty3 { get; set; }
    }
    public class Pera
    {
        public int MyProperty { get; set; }
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
    }
    public class Executa
    {
        public string Exec(int count, int value)
        {
            int x = 0;
            Random random = new Random();
            Stopwatch time = new Stopwatch();
            time.Start();
            while (x < count)
            {
                if (value == 0)
                {
                    var obj = new Pera();
                }
                else if (value == 1)
                {
                    Pera obj = new Pera();
                }
                else if (value == 2)
                {
                    var obj = new Banana();
                }
                else if (value == 3)
                {
                    var obj = (0 == random.Next(0, 1) ? new Fruta(new Manga()).GetInstance() : new Fruta(new Pera()).GetInstance());
                }
                else
                {
                    Banana obj = new Banana();
                }
                x++;
            }
            time.Stop();
            return time.Elapsed.ToString();
        }
        public void ExecManga()
        {
            var obj = new Fruta(new Manga()).GetInstance();
            Manga obj2 = obj;
        }
        public void ExecPera()
        {
            var obj = new Fruta(new Pera()).GetInstance();
            Pera obj2 = obj;
        }
    }
