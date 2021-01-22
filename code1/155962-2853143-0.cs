    foreach (var e in Assembly.GetCallingAssembly().Evidence)
    {
        if (e is StrongName)
        {
            Console.WriteLine(((StrongName)e).PublicKey.ToString());
        }
    }
