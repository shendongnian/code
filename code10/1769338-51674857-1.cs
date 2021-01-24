    public partial class MainForm : Form
    {
      public delegate void LogAction(string message, params object[] args);
      public void Logger(string message, params object[] args)
      {
        if (args != null)
          textBoxLog.AppendText(string.Format(message, args) + Environment.NewLine);
        else
          textBoxLog.AppendText(message + Environment.NewLine);
        Application.DoEvents();
      }
      
      private void buttonInstall_Click(object sender, EventArgs e)
      {
        Logger("Button clicked");
        using (Stream zipStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(MethodBase.GetCurrentMethod().DeclaringType.Namespace + ".Resources.test.zip"))
        using (ZipArchive zip = new ZipArchive(zipStream))
          zip.ExtractToDirectory(Program.DestinationInstallation, Logger);
    }
---
    public static class ZipFileExtensions
    {
      public static void ExtractToDirectory(this ZipArchive source, string destinationDirectoryName, MainForm.LogAction myLogger)
      {
        int number = 20180803;
        myLogger("{0} >> {1} (ok)", DateTime.Now, number);
      }
    }
