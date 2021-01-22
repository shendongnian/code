    static void Main(string[] args)
    {
        if (args.Length == 1 && args[0]=="job")
        {
            //because stdout has been used by send back, our logs should put to stderr
            Log.SetLogOutput(Console.Error); 
            try
            {
                var url = Console.ReadLine();
                var bmp = new WebPageShooterCr().Shoot(url);
                var buf = Serz(bmp);
                Console.WriteLine(buf.Length);
                System.Threading.Thread.Sleep(100);
                using (var o = Console.OpenStandardOutput())
                    o.Write(buf, 0, buf.Length);
            }
            catch (Exception ex)
            {
                Log.E("Err:" + ex.Message);
            }
        }
        //...
    }
