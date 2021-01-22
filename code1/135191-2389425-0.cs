    C#
    ==
    
    Main()
    {
       StartNewThread(MyThread);
       DoStuff();
    }
    
    MyThread()
    {
        UnmanagedDll.DoSomething();
    }
    
    Unmanaged DLL
    =============
    DoSomething()
    {
        // Does something here
    }
