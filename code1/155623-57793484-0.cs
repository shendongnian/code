    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using Shell32;
    
    namespace VolumeLabels
    {
        static class Drives
        {
            [DebuggerDisplay("Name: '{Name,nq}', Path: '{Path,nq}'")]
            public struct DriveNameInfo
            {
                public string Name { get; }
                public string Path { get; }
    
                public DriveNameInfo(string name, string path)
                {
                    Name = name;
                    Path = path;
                }
    
                public override string ToString()
                {
                    return Name;
                }
            }
    
            private static dynamic _shellObject;
            private static dynamic ShellObject => _shellObject ?? (_shellObject = Activator.CreateInstance(Type.GetTypeFromProgID("Shell.Application")));
    
            public static IEnumerable<DriveNameInfo> Get()
            {
                foreach (var driveInfo in DriveInfo.GetDrives())
                {
                    var driveData = (Folder2)ShellObject.NameSpace(driveInfo.Name);
                    if (driveData == null)
                        yield break;
                    var driveDataSelf = driveData.Self;
    
                    yield return new DriveNameInfo(driveDataSelf.Name, driveDataSelf.Path);
                }
            }
        }
        
        class Program
        {
            static void Main(string[] args)
            {
                foreach (var driveNameInfo in Drives.Get())
                    Console.WriteLine(driveNameInfo);
    
                Console.ReadKey(true);
            }
        }
    }
