    using System;
    using Karambolo.Common;
    using Karambolo.Common.Localization;
    class Program
    {
        static void Main(string[] args)
        {
            var ts = new TimeSpan(3, 13, 1, 52);
            Console.WriteLine(ts.ToTimeReference(4, "{0}", "now", "{0}", DefaultTextLocalizer.Instance));
        }
    }
