        var sid = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
        var mutexsecurity = new MutexSecurity();
        mutexsecurity.AddAccessRule(new MutexAccessRule(sid, MutexRights.FullControl, AccessControlType.Allow));
        mutexsecurity.AddAccessRule(new MutexAccessRule(sid, MutexRights.ChangePermissions, AccessControlType.Deny));
        mutexsecurity.AddAccessRule(new MutexAccessRule(sid, MutexRights.Delete, AccessControlType.Deny));
        _mutex = new Mutex(false, "Global\\YourAppName-{add-your-random-chars}", out created, mutexsecurity);
