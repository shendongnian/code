    [Guid("7279003B-0619-4E19-95BC-F22BD29CC950")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ITestEvent
    {
        [DispId(0x0001)]
        void OnSetString();
    }
