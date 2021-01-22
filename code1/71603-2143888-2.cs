    using System;
    using System.Threading;
    using System.Reflection;
    using System.Runtime.InteropServices;
    namespace System.Runtime.InteropServices
    {
        public class PinnedObject : IDisposable
        {
            private GCHandle gcHandle = new GCHandle();
            public PinnedObject(object o)
            {
                gcHandle = GCHandle.Alloc(o, GCHandleType.Pinned);
            }
            public unsafe static implicit operator byte*(PinnedObject po)
            {
                return (byte*)po.gcHandle.AddrOfPinnedObject();
            }
            #region IDisposable Members
            public void Dispose()
            {
                if (gcHandle.IsAllocated)
                {
                    gcHandle.Free();
                }
            }
            #endregion
        }
        public class PackedStructMarshaler<T> : ICustomMarshaler where T : struct
        {
            private static ICustomMarshaler m_instance = new PackedStructMarshaler<T>();
            public static ICustomMarshaler GetInstance()
            {
                return m_instance;
            }
            private void ForEachField(Action<FieldInfo> action)
            {
                foreach (var fi in typeof(T).GetFields(BindingFlags.Public | BindingFlags.NonPublic))
                {
                    // System.Diagnostics.Debug.Assert(fi.IsValueType);
                    action(fi);
                }
            }
            private unsafe void MemCpy(byte* dst, byte* src, int numBytes)
            {
                for (int i = 0; i < numBytes; i++)
                {
                    dst[i] = src[i];
                }
            }
            #region ICustomMarshaler Members
            public void CleanUpManagedData(object ManagedObj)
            {
            }
            public void CleanUpNativeData(IntPtr pNativeData)
            {
                Marshal.FreeHGlobal(pNativeData);
            }
            public int GetNativeDataSize()
            {
                unsafe
                {
                    int ret = 0;
                    ForEachField(
                        (FieldInfo fi) =>
                        {
                            Type ft = fi.FieldType;
                            ret += Marshal.SizeOf(ft);
                        });
                    return ret;
                }
            }
            private object m_marshaledObj = null;
            public unsafe IntPtr MarshalManagedToNative(object obj)
            {
                IntPtr nativeData = (IntPtr)0;
                if (obj != null)
                {
                    if (m_marshaledObj != null)
                        throw new ApplicationException("This instance has already marshaled a managed type");
                    m_marshaledObj = obj;
                    nativeData = Marshal.AllocHGlobal(GetNativeDataSize());
                    byte* pData = (byte*)nativeData;
                    int offset = 0;
                    ForEachField(
                        (FieldInfo fi) =>
                        {
                            int size = Marshal.SizeOf(fi.FieldType);
                            using (PinnedObject po = new PinnedObject(fi.GetValue(obj)))
                            {
                                MemCpy(pData + offset, po, size);
                            }
                            offset += size;
                        });
                }
                return nativeData;
            }
            public object MarshalNativeToManaged(IntPtr pNativeData)
            {
                if (m_marshaledObj != null)
                    m_marshaledObj = null;
                unsafe
                {
                    byte* pData = (byte*)pNativeData;
                    int offset = 0;
                    object res = new T();
                    ForEachField(
                        (FieldInfo fi) =>
                        {
                            int size = Marshal.SizeOf(fi.FieldType);
                            fi.SetValue(res, (object)(*((byte*)(pData + offset))));
                            offset += size;
                        });
                    return res;
                }
            }
            #endregion
        }
    }
