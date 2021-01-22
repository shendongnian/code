    // Visual C code:
    // (.NET functions use the __stdcall calling convention by default.)
    typedef void (__stdcall *Callback)(PCWSTR);
    void __declspec(dllexport) Foo(Callback c)
    {
        c(L"Hello world");
    }
    // C# code:
    // (A delegate declaration can include marshaling commands that
    // control how argument types are converted.)
    public delegate void Callback([MarshalAs(UnmanagedType.LPWStr)] string message);
    void PrintOut(string message) { Console.WriteLine(message); }
