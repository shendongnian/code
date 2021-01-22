       [Guid("332C4425-26CB-11D0-B483-00C04FD90119")]
        [ComImport]
        [TypeLibType((short)4160)]
        [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
        internal interface IHTMLDocument2
        {
            [DispId(1054)]
            void write([MarshalAs(UnmanagedType.BStr)] string psArray);
            //void write([MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] object[] psarray);
