    static CallIntoUnmanagedCode(MyManagedDelegate *delegate)
    {
        MyManagedDelegate __pin *pinnedDelegate = delegate;
        SOME_CALLBACK_PTR p = Marshal::GetFunctionPointerForDelegate(pinnedDelegate);
        CallDeepIntoUnmanagedCode(p); // this will call p
    }
