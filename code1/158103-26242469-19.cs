     // ...
    internal class Script
        static string myWIX_SET_DIRECTORY_STATEMENT = "    <SetDirectory Id=\"INSTALLDIR\" Value=\"D:\\Program Files\\DOL\\WA.DOL.HQSYS.ExecECL\" />";
        static string myWIX_INSERT_AFTER_TEXT = "    <InstallExecuteSequence >";
        public static void Main()
        {
        // ... (your other Wix# code goes here...)
            // Hook an event to Wix# save of .wxs file to post-process the .wxs
            Compiler.WixSourceSaved += PostProcessWxsXMLOutput;
            // Trigger the MSI file build
            Compiler.BuildMsi(project);
        }
        /// <summary>
        /// Post-process the Wix .wxs file before compiling it into an MSI
        /// </summary>
        /// <param name="wxsFileName"></param>
        private static void PostProcessWxsXMLOutput(string wxsFileName)
        {
            StreamReader sr = new StreamReader(wxsFileName);
            string myWixDocument = sr.ReadToEnd();
            sr.Close();
            string myProcessedWixDocument = WiXHelpers.InsertFragmentInWiXDocument(myWixDocument, myWIX_INSERT_AFTER_TEXT, myWIX_SET_DIRECTORY_STATEMENT);
            StreamWriter sw = new StreamWriter(wxsFileName);
            sw.Write(myProcessedWixDocument);
            sw.Close();
        }
