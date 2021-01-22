        [DllImport("msi.dll", CharSet = CharSet.Unicode)]
        static extern Int32 MsiGetProductInfo(string product, string property, [Out] StringBuilder valueBuf, ref Int32 len);
        static void Main(string[] args)
        {
            Int32 len = 512;
            var builder = new StringBuilder(len);
            MsiGetProductInfo("{0db93d2f-a9e7-417f-9425-5e61e82c0868}", "InstallDate", builder, ref len);
            var installDate = DateTime.ParseExact(builder.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            Console.WriteLine(installDate);
        }
