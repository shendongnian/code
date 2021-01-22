    class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool SetConsoleOutputCP(uint wCodePageID);
        static void Main(string[] args)
        {
            SetConsoleOutputCP(65001);
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("tést, тест, τεστ, ←↑→↓∏∑√∞①②③④, Bài viết chọn lọc");
            Console.ReadLine();
        }
    }
