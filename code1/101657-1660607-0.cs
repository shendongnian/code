    private static void Method2()
    {
        List<Methodx> list = new List<Methodx>();
        Methodx item = null;
        <>c__DisplayClassa classa = new <>c__DisplayClassa();
        classa.i = 0;
        while (classa.i < 5)
        {
            if (item == null)
            {
                item = new Methodx(classa.<Method2>b__8);
            }
            list.Add(item);
            classa.i++;
        }
        foreach (Methodx methodx2 in list)
        {
            Console.WriteLine("In main method c = " + methodx2(null));
        }
    }
