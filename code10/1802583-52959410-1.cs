    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication75
    {
        class Program
        {
             static void Main(string[] args)
            {
                //u = user
                //g = group
                //s = system
                //r = read
                //w = write
                //e = execute
                //array below represents the normal position of the permissions
                List<string> permissions = new List<string>() { "ue", "uw", "ur", "ge", "gw", "gr", "se", "sw", "sr" };
                //below is the order we actually want
                List<string> sortOrder = new List<string>() { "ue", "ge", "se", "uw", "gw", "sw", "ur", "gr", "sr" };
                List<cFile> files = new List<cFile>() {
                    new cFile() { name = "A", permission = 0x001},
                    new cFile() { name = "B", permission = 0x002},
                    new cFile() { name = "C", permission = 0x004},
                    new cFile() { name = "D", permission = 0x008},
                    new cFile() { name = "E", permission = 0x010},
                    new cFile() { name = "F", permission = 0x020},
                    new cFile() { name = "G", permission = 0x040},
                    new cFile() { name = "H", permission = 0x080},
                    new cFile() { name = "I", permission = 0x100}
                };
     
                //now reorder the columns
                 var tempData = files.Select(x => new { files = x, shiftedPermissions =  Enumerable.Range(0, 9).Select(y => (permissions.IndexOf(sortOrder[y]) - y >= 0) ?
                    (1 << y) & (x.permission >> (permissions.IndexOf(sortOrder[y]) - y)) :
                    (1 << y) & (x.permission << (y - permissions.IndexOf(sortOrder[y])))).Sum()
                 }).ToList();
                 List<cFile> sortedPermissions = tempData.OrderBy(x => x.shiftedPermissions).Select(x => x.files).ToList();
            }
     
        }
        public class cFile
        {
            public string name { get; set; }
            public UInt32 permission { get; set; }
        }
    }
