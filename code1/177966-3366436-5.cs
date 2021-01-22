    // This is declared in a class
    static CallIntoUnamangedCode(MyManagedDelegate ^delegate)
    {
        pin_ptr<MyManagedDelegate ^> pinnedDelegate = &delegate;
        SOME_CALLBACK_PTR p = Marshal::GetFunctionPointerForDelegate(pinnedDelegate);
        CallDeepIntoUnmanagedCode(p); // This will call p
    }
