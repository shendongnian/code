    [ComImport, ComVisible(true), Guid(@"3050f28b-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLScriptElement
    {
        [DispId(1006)]
        string text { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
    }
