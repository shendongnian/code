    using System.Drawing.Printing;
    //...
      foreach (string printerName in PrinterSettings.InstalledPrinters)
      {
        // Display the printer name.
        Console.WriteLine("Printer: {0}", printerName);
 
        // Retrieve the printer settings.
        PrinterSettings printer = new PrinterSettings();
        printer.PrinterName = printerName;
 
        // Check that this is a valid printer.
        // (This step might be required if you read the printer name
        // from a user-supplied value or a registry or configuration file
        // setting.)
        if (printer.IsValid)
        {
          // Display the list of valid resolutions.
          Console.WriteLine("Supported Resolutions:");
 
          foreach (PrinterResolution resolution in
            printer.PrinterResolutions)
          {
            Console.WriteLine("  {0}", resolution);
          }
          Console.WriteLine();
 
          // Display the list of valid paper sizes.
          Console.WriteLine("Supported Paper Sizes:");
 
          foreach (PaperSize size in printer.PaperSizes)
          {
            if (Enum.IsDefined(size.Kind.GetType(), size.Kind))
            {
              Console.WriteLine("  {0}", size);
            }
          }
          Console.WriteLine();
        }
      }
