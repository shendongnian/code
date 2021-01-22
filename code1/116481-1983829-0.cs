    static class Program
    {
        [STAThread]
        static void Main()
        {
            Console.WriteLine("first string");
            var form = new Form1();
            form.Show();
            Console.WriteLine("the second string");
            Application.Run();
        }
    }
