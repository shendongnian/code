    using (PrintDialog printDialog1 = new PrintDialog())
    {
        if (printDialog1.ShowDialog() == DialogResult.OK)
        {
            var info = new ProcessStartInfo(**FILENAME**);
            info.Arguments = "\"" + printDialog1.PrinterSettings.PrinterName + "\"";
            // Use the debugger a message dialog to see 
            // contents of printDialog1.PrinterSettings
        }
    }
