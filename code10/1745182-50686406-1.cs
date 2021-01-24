    string username = "user-123";
    Mono.Unix.Native.Passwd pwd = Mono.Unix.Native.Syscall.getpwnam(username);
    // pwd.pw_uid
    string dir = pwd.pw_dir;
    System.Console.WriteLine((dir));
