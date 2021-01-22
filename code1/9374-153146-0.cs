    const string FILE = @"C:\test.txt";
    var fs = File.GetAccessControl(FILE);
    
    var sid = fs.GetOwner(typeof(SecurityIdentifier));
    Console.WriteLine(sid); // SID
    
    var ntAccount = sid.Translate(typeof(NTAccount));
    Console.WriteLine(ntAccount); // DOMAIN\username
