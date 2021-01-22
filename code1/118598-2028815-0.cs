    bool IsRunningMono()
    {
        // With our application, it will be used on an embedded system, and we know that
        // Windows will never be running Mono, so you may have to adjust accordingly.
        return Type.GetType("Mono.Runtime") != null;
    }
    
    string GetCPUSerial()
    {
        string serial = "";
        if(IsRunningMono())
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "lshw";
            startInfo.Arguments = "-xml";
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            using(Process p = Process.Start(startInfo))
            {
                p.WaitForExit();
                System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
                xdoc.Load(new System.Xml.XmlTextReader(new StringReader(p.StandardOutput.ReadToEnd())));
                System.Xml.XmlNodeList nodes = xdoc.SelectNodes("node/node/node/serial");
                if (nodes.Count > 0)
                {
                    serial = nodes[0].InnerText;              
                }
            }        
        }
        else
        {
           // process using wmi
        }
 
        return serial;
    }
