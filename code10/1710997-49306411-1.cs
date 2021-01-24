    static void Main(string[] args)
            {
                decimal dtdec = 20170415.00M;
                Int64 dtint = (Int64)dtdec;
                var newDate = DateTime.ParseExact(dtint.ToString(),
                                      "yyyyMMdd",
                                       System.Globalization.CultureInfo.InvariantCulture);
                Console.WriteLine(newDate);
                Console.WriteLine(newDate.ToShortDateString());
                Console.ReadKey();
            }
