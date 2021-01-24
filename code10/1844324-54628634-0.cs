    public class Program
        {
                    public static void Main(string[] args)
                    {
                        CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                        culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
                        culture.DateTimeFormat.LongTimePattern = "HH:mm:ss tt";
                        Thread.CurrentThread.CurrentCulture = culture;
                        CreateWebHostBuilder(args).Build().Run();
                    }
         }
