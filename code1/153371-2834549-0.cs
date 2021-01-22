    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Web;
    using System.Web.UI;
    public partial class utilities_getPDF : Page
    {
        protected void Page_Load(Object sender, EventArgs e)
        {
            string fileName = WKHtmlToPdf(myURL);
            if (!string.IsNullOrEmpty(fileName))
            {
                string file = Server.MapPath("~\\utilities\\GeneratedPDFs\\" + fileName);
                if (File.Exists(file))
                {
                    var openFile = File.OpenRead(file);
                    // copy the stream (thanks to http://stackoverflow.com/questions/230128/best-way-to-copy-between-two-stream-instances-c)
                    byte[] buffer = new byte[32768];
                    while (true)
                    {
                        int read = openFile.Read(buffer, 0, buffer.Length);
                        if (read <= 0)
                        {
                            break;
                        }
                        Response.OutputStream.Write(buffer, 0, read);
                    }
                    openFile.Close();
                    openFile.Dispose();
                    File.Delete(file);
                }
            }
        }
        public string WKHtmlToPdf(string Url)
        {
            var p = new Process();
            string switches = "";
            switches += "--print-media-type ";
            switches += "--margin-top 10mm --margin-bottom 10mm --margin-right 10mm --margin-left 10mm ";
            switches += "--page-size Letter ";
            // waits for a javascript redirect it there is one
            switches += "--redirect-delay 100";
            // Utils.GenerateGloballyUniuqueFileName takes the extension from
            // basically returns a filename and prepends a GUID to it (and checks for some other stuff too)
            string fileName = Utils.GenerateGloballyUniqueFileName("pdf.pdf");
            var startInfo = new ProcessStartInfo
                            {
                                FileName = Server.MapPath("~\\utilities\\PDF\\wkhtmltopdf.exe"),
                                Arguments = switches + " " + Url + " \"" +
                                            "../GeneratedPDFs/" + fileName
                                            + "\"",
                                UseShellExecute = false, // needs to be false in order to redirect output
                                RedirectStandardOutput = true,
                                RedirectStandardError = true,
                                RedirectStandardInput = true, // redirect all 3, as it should be all 3 or none
                                WorkingDirectory = Server.MapPath("~\\utilities\\PDF")
                            };
            p.StartInfo = startInfo;
            p.Start();
            // doesn't work correctly...
            // read the output here...
            // string output = p.StandardOutput.ReadToEnd();
            //  wait n milliseconds for exit (as after exit, it can't read the output)
            p.WaitForExit(60000);
            // read the exit code, close process
            int returnCode = p.ExitCode;
            p.Close();
            // if 0 or 2, it worked (not sure about other values, I want a better way to confirm this)
            return (returnCode <= 2) ? fileName : null;
        }
    }
