    var skyroomDirectory = Directory.CreateDirectory(@"C:\Program Files\Skyroom");
    
    DirectorySecurity security = skyroomDirectory.GetAccessControl();
    security.AddAccessRule(new FileSystemAccessRule(@"MYDOMAIN\JohnDoe", 
                            FileSystemRights.Modify, 
                            AccessControlType.Allow));
    skyroomDirectory.SetAccessControl(security);
    File.Create(@"C:\Program Files\Skyroom\gamedata.txt");
