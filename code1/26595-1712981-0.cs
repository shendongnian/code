    using System.Reflection;
    using System.Threading;
    using SHDocVw;
    
    namespace HTMLPrinting
    {
      public class HTMLPrinter
      {
        private bool documentLoaded;
        private bool documentPrinted;
    
        private void ie_DocumentComplete(object pDisp, ref object URL)
        {
          documentLoaded = true;
        }
    
        private void ie_PrintTemplateTeardown(object pDisp)
        {
          documentPrinted = true;
        }
    
        public void Print(string htmlFilename)
        {
          documentLoaded = false;
          documentPrinted = false;
    
          InternetExplorer ie = new InternetExplorerClass();
          ie.DocumentComplete += new DWebBrowserEvents2_DocumentCompleteEventHandler(ie_DocumentComplete);
          ie.PrintTemplateTeardown += new DWebBrowserEvents2_PrintTemplateTeardownEventHandler(ie_PrintTemplateTeardown);
    
          object missing = Missing.Value;
    
          ie.Navigate(htmlFilename, ref missing, ref missing, ref missing, ref missing);
          while (!documentLoaded && ie.QueryStatusWB(OLECMDID.OLECMDID_PRINT) != OLECMDF.OLECMDF_ENABLED)
            Thread.Sleep(100);
    
          ie.ExecWB(OLECMDID.OLECMDID_PRINT, OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, ref missing, ref missing);
          while (!documentPrinted)
            Thread.Sleep(100);
    
          ie.DocumentComplete -= ie_DocumentComplete;
          ie.PrintTemplateTeardown -= ie_PrintTemplateTeardown;
          ie.Quit();
        }
      }
    }
