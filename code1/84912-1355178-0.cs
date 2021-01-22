    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Scratch {
        class Program {
            static void Main(string[] args) {
                //var ids = new[] { 1000000012, 1000000021, 1000000013, 1000000022 };
                var rand = new Random();
                var ids = new int[rand.Next(20)];
                for(var i = 0; i < ids.Length; i++) {
                    ids[i] = rand.Next();
                }
    
                WriteIds(ids);
                var s = IdsToString(ids);
                Console.WriteLine("\nResult string is: {0}", s);
                var newIds = StringToIds(s);
                WriteIds(newIds);
                Console.ReadLine();
            }
    
            public static void WriteIds(ICollection<Int32> ids) {
                Console.Write("\nIDs: ");
                bool comma = false;
                foreach(var id in ids) {
                    if(comma) {
                        Console.Write(",");
                    } else {
                        comma = true;
                    }
                    Console.Write(id);
                }
                Console.WriteLine();
            }
    
            public static string IdsToString(ICollection<Int32> ids) {
                var allbytes = new List<byte>();
                foreach(var id in ids) {
                    var bytes = BitConverter.GetBytes(id);
                    allbytes.AddRange(bytes);                
                }
                var str = Convert.ToBase64String(allbytes.ToArray(), Base64FormattingOptions.None);
                return str.Replace('+', '-').Replace('/', '_').Replace('=', '.');
            }
    
            public static ICollection<Int32> StringToIds(string idstring) {
                var result = new List<Int32>();
                var str = idstring.Replace('-', '+').Replace('_', '/').Replace('.', '=');
                var bytes = Convert.FromBase64String(str);
                for(var i = 0; i < bytes.Length; i += 4) {
                    var id = BitConverter.ToInt32(bytes, i);
                    result.Add(id);
                }
                return result;
            }
        }
    }
