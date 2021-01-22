    interface IBase
    {
        string GetProperty1();
    }
    interface IInherited : IBase
    {
        void SetProperty1(string str);
    }
