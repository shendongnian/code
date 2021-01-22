    // Send it to the selected printer
    using (PrintDialog printDialog1 = new PrintDialog())
    {
        if (printDialog1.ShowDialog() == DialogResult.OK)
        {
            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(**FILENAME**);
            info.Arguments = "\"" + printDialog1.PrinterSettings.PrinterName + "\"";
            info.CreateNoWindow = true;
            info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            info.UseShellExecute = true;
            info.Verb = "PrintTo";
            System.Diagnostics.Process.Start(info);
        }
    }
