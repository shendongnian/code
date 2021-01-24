        Dictionary<string, Action<XmlDocument>> versionSpecificMethods = new Dictionary<string, Action<XmlDocument>>{
        {"1.0.0.0", DoStuff1},
        {"1.2.3.4", DoStuff2},
        {"3.1.7.182", DoStuff3}};
        private void RunMethodForVersion(string version, XmlDocument someXmlDoc)
        {
            var codeToRun = versionSpecificMethods[version];
            codeToRun.Invoke(someXmlDoc);
        }
        private static void DoStuff1(XmlDocument doc)
        {
            // Insert user code here
        }
