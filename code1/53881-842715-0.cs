    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SharpSvn;
    using Ionic.Zip;
    using System.IO;
    using SharpSvn.Security;
    
    namespace SvnExportDirectory
    {
        public class SvnToZip
        {
            public Uri SvnUri { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
    
            private bool passwordSupplied;
    
            public SvnToZip() { }
    
            public SvnToZip(Uri svnUri)
            {
                this.SvnUri = svnUri;
            }
    
            public SvnToZip(string svnUri)
                : this(new Uri(svnUri)) { }
    
            public void ToFile(string zipPath)
            {
                if (File.Exists(zipPath))
                    File.Delete(zipPath);
    
                using (FileStream stream = File.OpenWrite(zipPath))
                {
                    this.Run(stream);
                }
            }
    
            public MemoryStream ToStream()
            {
                MemoryStream ms = new MemoryStream();
                this.Run(ms);
                ms.Seek(0, SeekOrigin.Begin);
                return ms;
            }
    
            private void Run(Stream stream)
            {
                string tmpFolder =
                    Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
    
                try
                {
                    using (SvnClient client = new SvnClient())
                    {
                        //client.Authentication.Clear();
                        client.Authentication.UserNamePasswordHandlers += Authentication_UserNamePasswordHandlers;
    
                        SvnUpdateResult res;
                        bool downloaded = client.Export(SvnTarget.FromUri(SvnUri), tmpFolder, out res);
                        if (downloaded == false)
                            throw new Exception("Download Failed");
                    }
    
                    using (ZipFile zipFile = new ZipFile())
                    {
                        zipFile.AddDirectory(tmpFolder, GetFolderName());
                        zipFile.Save(stream);
                    }
                }
                finally
                {
                    if (File.Exists(tmpFolder))
                        File.Delete(tmpFolder);
                }
            }
    
    
            private string GetFolderName()
            {
                foreach (var potential in SvnUri.Segments.Reverse())
                {
                    if (string.Equals(potential, "trunk", StringComparison.InvariantCultureIgnoreCase) == false)
                        return potential;
                }
                return null;
            }
    
            void Authentication_UserNamePasswordHandlers(object sender, SvnUserNamePasswordEventArgs e)
            {
                if (passwordSupplied)
                {
                    e.Break = true;
                }
                else
                {
                    if (this.Username != null)
                        e.UserName = this.Username;
    
                    if (this.Password != null)
                        e.Password = this.Password;
    
                    passwordSupplied = true;
                }
            }
        }
    }
