    var watch = new Stopwatch();
    watch.Start();
    using (var service = new Cryptography("---"))
    {
        var listEncrypt = new List<string>();
        var listPlain = new List<string>();
        for (int i = 0; i < 1000; i++)
        {
            var encypt = service.Encrypt(i.ToString());
            listEncrypt.Add(encypt);
        }
        for (int i = 0; i < 1000; i++)
        {
            var plain = service.Decrypt(listEncrypt[i]);
            listPlain.Add(plain);
        }
    }
    watch.Stop();
    Console.WriteLine(watch.Elapsed.Milliseconds.ToString());
    Console.Read();
