    var accessRules = groupDe.ObjectSecurity.GetAccessRules(true, true, typeof(NTAccount));
    
    foreach (ActiveDirectoryAccessRule ar in accessRules)
    {
        Console.WriteLine($"{ar.IdentityReference.ToString()}");
        Console.WriteLine($"Inherits - {ar.InheritanceType.ToString()}");
        Console.WriteLine($"ObjectType - {ar.ObjectType.ToString()}");
        Console.WriteLine($"InheritedObjectType - {ar.InheritedObjectType.ToString()}");
        Console.WriteLine($"ObjectFlags - {ar.ObjectFlags.ToString()}");
        Console.WriteLine($"AccessControlType - {ar.AccessControlType.ToString()}");
        Console.WriteLine($"ActiveDirectoryRights - {ar.ActiveDirectoryRights.ToString()}");
    
    
        Console.WriteLine($"IsInherited - {ar.IsInherited.ToString()}");
        Console.WriteLine($"PropagationFlags - {ar.PropagationFlags.ToString()}");
        Console.WriteLine("-------");
    }
