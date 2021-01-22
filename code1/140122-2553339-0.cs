            string sError = "";
            string VDName = "MY";
            vr.Create("IIS://localhost/W3SVC/1/Root", physicalPath, VDName, out sError);
            if (sError.Trim().Length > 0)
                throw new Exception("Error when creating Virtual Directory:" + Environment.NewLine + sError);
            DirectoryEntry deVDir = new DirectoryEntry("IIS://localhost/W3SVC/1/Root/" + VDName);
            deVDir.Properties["Path"].Value = physicalPath;
            deVDir.Properties["DefaultDoc"].Value = "Mainscreen1.aspx";
            foreach (PropertyValueCollection val in deVDir.Properties)
            {
                Console.WriteLine(val.PropertyName);
            }
            
            PropertyValueCollection vals = deVDir.Properties["ScriptMaps"];
            ArrayList objScriptMaps = new ArrayList();
                      objScriptMaps.Add(val.Replace(version,frameworkVersion));
            
           
       
            string _frameWorkDir;
            string _Dir;
            string _FrameWorkVersion = "2.0.50727";
            _Dir = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();
            int dirpos = _Dir.Remove(_Dir.Length - 1, 1).LastIndexOf(@"\");
            _frameWorkDir = _Dir.Remove(dirpos, _Dir.Length - dirpos);
            _frameWorkDir = _frameWorkDir + @"\v" + _FrameWorkVersion + @"\";
            Process pro = new Process();
            pro.StartInfo.UseShellExecute = false;
            pro.StartInfo.RedirectStandardOutput = true;
            pro.StartInfo.RedirectStandardError = true;
            pro.StartInfo.FileName = _frameWorkDir + "aspnet_regiis";
           pro.StartInfo.Arguments = @"-s " + @"/W3SVC/1/Root/";
            
            pro.Start();
            pro.WaitForExit();
