    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using System.Security;
    using System.Security.AccessControl;
    using aejw.Network;
    
    namespace SecurityScanner
    {
        class Program
        {
            static void Main(string[] args)
            {
                string path = @"\\mynetworkdir";
                DirectoryInfo di = new DirectoryInfo(path);
                List<DirSec> dirs = new List<DirSec>();
                RecordSecurityData(di, dirs, path, path);
    
                //Grouping up my users
                List<List<DirSec>> groups = new List<List<DirSec>>();
                foreach (DirSec d in dirs)
                {
                    bool IsNew = true;
                    foreach (List<DirSec> group in groups)
                    {
                        if (d.IsSameUserList(group[0]))
                        {
                            group.Add(d);
                            IsNew = false;
                            break;
                        }
                    }
                    if (IsNew)
                    {
                        List<DirSec> newGroup = new List<DirSec>();
                        newGroup.Add(d);
                        groups.Add(newGroup);
                    }
                }
    
                //Outputting my potential user groups
                StringBuilder sb = new StringBuilder();
                foreach (List<DirSec> group in groups)
                {
                    foreach (DirSec d in group)
                    {
                        sb.AppendLine(d.DirectoryName);
                    }
                    foreach (string s in group[0].UserList)
                    {
                        sb.AppendLine("\t" + s);
                    }
                    sb.AppendLine();
                }
                File.WriteAllText(@"c:\security.txt", sb.ToString());
            }
    
            public static void RecordSecurityData(DirectoryInfo di, List<DirSec> dirs, string path, string fullPath)
            {
                DirSec me = new DirSec(fullPath);
                DirectorySecurity ds;
                NetworkDrive nd = null;
                if(path.Length <= 248)
                    ds = Directory.GetAccessControl(path);
                else
                {
                    nd = new NetworkDrive();
                    nd.LocalDrive = "X:";
                    nd.ShareName = path;
                    nd.MapDrive();
                    path = @"X:\";
                    di = new DirectoryInfo(path);
                    ds = Directory.GetAccessControl(path);
                }
                foreach (AuthorizationRule ar in ds.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
                {
                    me.AddUser(ar.IdentityReference.Value);
                }
                dirs.Add(me);
                foreach (DirectoryInfo child in di.GetDirectories())
                {
                    RecordSecurityData(child, dirs, path + @"\" + child.Name, fullPath + @"\" + child.Name);
                }
                if (nd != null)
                    nd.UnMapDrive();
            }
    
            public struct DirSec
            {
                public string DirectoryName;
                public List<string> UserList;
    
                public DirSec(string directoryName)
                {
                    DirectoryName = directoryName;
                    UserList = new List<string>();
                }
    
                public void AddUser(string UserName)
                {
                    UserList.Add(UserName);
                }
    
                public bool IsSameUserList(DirSec other)
                {
                    bool isSame = false;
                    if (this.UserList.Count == other.UserList.Count)
                    {
                        isSame = true;
                        foreach (string myUser in this.UserList)
                        {
                            if (!other.UserList.Contains(myUser))
                            {
                                isSame = false;
                                break;
                            }
                        }
                    }
                    return isSame;
                }
            }
        }
    }
