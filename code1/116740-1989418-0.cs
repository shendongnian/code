     DateTime dt = DateTime.Now;
          // Sets the CurrentCulture property to U.S. English.
          Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
          // Displays dt, formatted using the ShortDatePattern
          // and the CurrentThread.CurrentCulture.
          Console.WriteLine(dt.ToString("20100102"));
          
          // Creates a CultureInfo for German in Germany.
          CultureInfo ci = new CultureInfo("de-DE");
          // Displays dt, formatted using the ShortDatePattern
          // and the CultureInfo.
          Console.WriteLine(dt.ToString("20100102", ci));
