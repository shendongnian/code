    [Guid("962232c8-90b2-4b61-8ef3-83298901c63e")]
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ICSCOMCLASS
    {
        [DispId(1)]
        void TestInParameter(double num);
        [DispId(2)]
        void TestOutParameter(out double num);
        [DispId(3)]
        void TestRefParameter(ref double num);
    }
