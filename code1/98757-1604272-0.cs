    //using System.IO;
    //using System.Security.AccessControl;
    //using System.Security.Principal;
    string[] directories = Directory.GetDirectories(
        Path.Combine(Environment.CurrentDirectory, @"..\.."), 
        "*", SearchOption.AllDirectories);
    foreach (string directory in directories)
    {
        DirectoryInfo info = new DirectoryInfo(directory);
        DirectorySecurity security = info.GetAccessControl();
        Console.WriteLine(info.FullName);
        foreach (FileSystemAccessRule rule in 
                 security.GetAccessRules(true, true, typeof(NTAccount)))
        {
            Console.WriteLine("\tIdentityReference = {0}", rule.IdentityReference);
            Console.WriteLine("\tInheritanceFlags  = {0}", rule.InheritanceFlags );
            Console.WriteLine("\tPropagationFlags  = {0}", rule.PropagationFlags );
            Console.WriteLine("\tAccessControlType = {0}", rule.AccessControlType);
            Console.WriteLine("\tFileSystemRights  = {0}", rule.FileSystemRights );
            Console.WriteLine();
        }
    }
