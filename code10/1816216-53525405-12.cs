    public class DelphiShortStringMarshaler : ICustomMarshaler
    {
        private int maxChars;
        public DelphiShortStringMarshaler(uint maxChars)
        {
            this.maxChars = (int) Math.Min(maxChars, 255);
        }
        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            int strLen = (int) Marshal.ReadByte(pNativeData);
            string str;
            if (strLen > 0)
                str = Marshal.PtrToStringAnsi(IntPtr.Add(pNativeData, 1), strLen);
            else
                str = "";
            return str;
        }
        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            // Managed Object must be a string type.
            if (!(ManagedObj is string))
                throw new ArgumentException("The input argument is not a string type.");
            string str = (string) ManagedObj;
            byte[] strBytes = System.Text.Encoding.Default.GetBytes(str);
            int strLen = Math.Min(strBytes.Length, maxChars);
            IntPtr pResult = Marshal.AllocHGlobal(GetNativeDataSize());
            Marshal.WriteByte(pResult, (byte) strLen);
            if (strLen > 0)
                Marshal.Copy(strBytes, 0, IntPtr.Add(pResult, 1), strLen);
            return pResult;
        }
        public void CleanUpNativeData(IntPtr pNativeData)
        {
            Marshal.FreeHGlobal(pNativeData);
        }
        public void CleanUpManagedData(object ManagedObj)
        {
            // Nothing to do
        }
        public int GetNativeDataSize()
        {
            return 1 + maxChars;
        }
        public static ICustomMarshaler GetInstance(string cookie)
        {
            return new DelphiShortStringMarshaler(uint.Parse(cookie));
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ReturnStruct
    {
        public int i;
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DelphiShortStringMarshaler), MarshalCookie = "50")]
        public string card;
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DelphiShortStringMarshaler), MarshalCookie = "100")]
        public string name;
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DelphiShortStringMarshaler), MarshalCookie = "5")]
        public string responsecode;
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DelphiShortStringMarshaler), MarshalCookie = "100")]
        public string responsetext;
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DelphiShortStringMarshaler), MarshalCookie = "15")]
        public string approval;
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DelphiShortStringMarshaler), MarshalCookie = "50")]
        public string tranid;
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DelphiShortStringMarshaler), MarshalCookie = "16")]
        public string reference;
        public double d;
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DelphiShortStringMarshaler), MarshalCookie = "24")]
        public string transactionType;
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DelphiShortStringMarshaler), MarshalCookie = "10")]
        public string creditCardType;
        public int EMVContact;
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DelphiShortStringMarshaler), MarshalCookie = "50")]
        public string applicationName;
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DelphiShortStringMarshaler), MarshalCookie = "15")]
        public string applicationIdentifier;
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DelphiShortStringMarshaler), MarshalCookie = "10")]
        public string reserved;
    }
    public ReturnStruct GetReturnStruct()
    {
        var ret = new ReturnStruct();
        ret.i = ...;
        ret.card = ...;
        ret.name = ...;
        ret.responsecode = ...;
        ret.responsetext = ...;
        ret.approval = ...;
        ret.tranid = ...;
        ret.reference = ...;
        ret.d = ...;
        ret.transactionType = ...;
        ret.creditCardType = ...;
        ret.EMVContact = ...;
        ret.applicationName = ...;
        ret.applicationIdentifier = ...;
        ret.reserved = ...;
        return ret;
    }
