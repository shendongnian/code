    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ExceptList
    {
        class Program
        {
            static void Main(string[] args)
            {
                var sourceFileNames = new List<FileList>();
    
                sourceFileNames.Add(new FileList { FileNames = "1.txt" });
                sourceFileNames.Add(new FileList { FileNames = "2.txt" });
                sourceFileNames.Add(new FileList { FileNames = "3.txt" });
                sourceFileNames.Add(new FileList { FileNames = "4.txt" });
    
                List<FileList> destinationFileNames = new List<FileList>();
                destinationFileNames.Add(new FileList { FileNames = "1.txt" });
                destinationFileNames.Add(new FileList { FileNames = "2.txt" });
    
                var except = sourceFileNames.Except(destinationFileNames);
    
                
                // list only 3 and 4
                foreach (var f in except)
                    Console.WriteLine(f.FileNames);
    
                Console.ReadLine();
            }
        }
    
        class FileList :  IEquatable<FileList>
        {
            public string FileNames { get; set; }
    
    
            #region IEquatable<FileList> Members
    
            public bool Equals(FileList other)
            {
                //Check whether the compared object is null.
                if (Object.ReferenceEquals(other, null)) return false;
    
                //Check whether the compared object references the same data.
                if (Object.ReferenceEquals(this, other)) return true;
    
                return FileNames.Equals(other.FileNames);
    
            }        
    
            #endregion
    
            public override int GetHashCode()
            {
                return FileNames.GetHashCode();
            }
        }
    
    }
