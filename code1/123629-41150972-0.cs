    public static class NumberDisplayHelper
    {
        public static string KiloFormat(this decimal number)
        {
            return number >= 1000
                ? $"{(number / 1000):0.##}K"
                : number.ToString(CultureInfo.CurrentCulture);
        }
        public static string KiloFormat(this int number)
        {
            return number >= 1000
                ? $"{((decimal)number / 1000):0.##}K"
                : number.ToString();
        }
    }
    [Test()]
    public void KiloFormatter()
    {
        Assert.AreEqual("900", 900m.KiloFormat());
        Assert.AreEqual("1,2K", 1203m.KiloFormat());
        Assert.AreEqual("1,59K", 1588.84m.KiloFormat());
        Assert.AreEqual("1,52K", 1522.84m.KiloFormat());
        Assert.AreEqual("589", 589.KiloFormat());
        Assert.AreEqual("1K", 1001.KiloFormat());
        Assert.AreEqual("1,46K", 1455.KiloFormat());
        Assert.AreEqual("1K", 1000m.KiloFormat());
    }
