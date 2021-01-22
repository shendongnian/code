    using System.Runtime.InteropServices;
    using System.Threading;
    public class Sample
    {
        [DllImport("sample.dll")]
        public static extern void TestDataMethod([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(TestDataMarshaler))] TestDataStruct pData);
    }
    public class TestDataStruct
    {
        public byte data1;
        public int data2;
        public byte[] data3 = new byte[7];
        public long data4;
        public byte data5;
    }
    public class TestDataMarshaler : ICustomMarshaler
    {
        //thread static since this could be called on 
        //multiple threads at the same time.
        [ThreadStatic()]
        private static TestDataStruct m_MarshaledInstance;
        private static ICustomMarshaler m_Instance = new TestDataMarshaler();
        public static ICustomFormatter GetInstance(string cookie)
        {
            return m_Instance;
        }
        #region ICustomMarshaler Members
        public void CleanUpManagedData(object ManagedObj)
        {
            //nothing to do.
        }
        public void CleanUpNativeData(IntPtr pNativeData)
        {
            Marshal.FreeHGlobal(pNativeData);
        }
        public int GetNativeDataSize()
        {
            return 21;
        }
        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            m_MarshaledInstance = (TestDataStruct)ManagedObj;
            IntPtr nativeData = Marshal.AllocHGlobal(GetNativeDataSize());
            if (m_MarshaledInstance != null)
            {
                unsafe //unsafe is simpler but can easily be done without unsafe if necessary
                {
                    byte* pData = (byte*)nativeData;
                    *pData = m_MarshaledInstance.data1;
                    *(int*)(pData + 1) = m_MarshaledInstance.data2;
                    Marshal.Copy(m_MarshaledInstance.data3, 0, (IntPtr)(pData + 5), 7);
                    *(long*)(pData + 12) = m_MarshaledInstance.data4;
                    *(pData + 20) = m_MarshaledInstance.data5;
                }
            }
            return nativeData;
        }
        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            TestDataStruct data = m_MarshaledInstance;
            m_MarshaledInstance = null; //clear out TLS for next call.
            if (data == null) data = new TestDataStruct(); //if no in object then return a new one
            unsafe //unsafe is simpler but can easily be done without unsafe if necessary
            {
                byte* pData = (byte*)pNativeData;
                data.data1 = *pData;
                data.data2 = *(int*)(pData + 1);
                Marshal.Copy((IntPtr)(pData + 5), data.data3, 0, 7);
                data.data4 = *(long*)(pData + 12);
                data.data5 = *(pData + 20);
            }
            return data;
        }
        #endregion
    }
