    private static void EasterBunnyTest()
    {
        AbstractEasterBunny WesternEuropeanBunny = new CatholicEasterBunny();
        AbstractEasterBunny EasternEuropeanBunny = new OrthodoxEasterBunny();
        AbstractEasterBunny LocalizedEasterBunyn = AbstractEasterBunny.CreateInstance();
        System.DateTime dtRomeEaster = WesternEuropeanBunny.EasterSunday(2016);
        System.DateTime dtAthensEaster = EasternEuropeanBunny.EasterSunday(2016);
        System.DateTime dtLocalEaster = LocalizedEasterBunyn.EasterSunday(2016);
        System.Console.WriteLine(dtRomeEaster);
        System.Console.WriteLine(dtAthensEaster);
        System.Console.WriteLine(dtLocalEaster);
    }
