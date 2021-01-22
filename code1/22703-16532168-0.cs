        private bool IncreaseFileVersionBuild()
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                try
                {
                    var fi = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.GetDirectories("Properties")[0].GetFiles("AssemblyInfo.cs")[0];
                    var ve = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    string ol = ve.FileMajorPart.ToString() + "." + ve.FileMinorPart.ToString() + "." + ve.FileBuildPart.ToString() + "." + ve.FilePrivatePart.ToString();
                    string ne = ve.FileMajorPart.ToString() + "." + ve.FileMinorPart.ToString() + "." + (ve.FileBuildPart + 1).ToString() + "." + ve.FilePrivatePart.ToString();
                    System.IO.File.WriteAllText(fi.FullName, System.IO.File.ReadAllText(fi.FullName).Replace("[assembly: AssemblyFileVersion(\"" + ol + "\")]", "[assembly: AssemblyFileVersion(\"" + ne + "\")]"));
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
