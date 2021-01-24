    [Guid("962232c8-90b2-4b61-8ef3-83298901c63e")]
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICSCOMCLASS
    {
        void TestInParameter(double num);
        void TestOutParameter(out double num);
        void TestRefParameter(ref double num);
    }
