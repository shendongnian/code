    var Value = Memory.ReadMemory<type>(offset);
----------
    internal class Memory {
            private static Process m_iProcess;
            private static IntPtr m_iProcessHandle;
    
            private static int m_iBytesWritten;
            private static int m_iBytesRead;
    
            public static bool Attatch(string ProcName) {
                if (Process.GetProcessesByName(ProcName).Length > 0) {
                    m_iProcess = Process.GetProcessesByName(ProcName)[0];
                    m_iProcessHandle =
                        Imports.OpenProcess(Flags.PROCESS_VM_OPERATION | Flags.PROCESS_VM_READ | Flags.PROCESS_VM_WRITE,
                            false, m_iProcess.Id);
                    return true;
                }
    
                return false;
            }
    
            public static void WriteMemory<T>(int Address, object Value) {
                var buffer = StructureToByteArray(Value);
    
                Imports.NtWriteVirtualMemory((int) m_iProcessHandle, Address, buffer, buffer.Length, out m_iBytesWritten);
            }
    
            public static void WriteMemory<T>(int Adress, char[] Value) {
                var buffer = Encoding.UTF8.GetBytes(Value);
    
                Imports.NtWriteVirtualMemory((int) m_iProcessHandle, Adress, buffer, buffer.Length, out m_iBytesWritten);
            }
    
            public static T ReadMemory<T>(int address) where T : struct {
                var ByteSize = Marshal.SizeOf(typeof(T));
    
                var buffer = new byte[ByteSize];
    
                Imports.NtReadVirtualMemory((int) m_iProcessHandle, address, buffer, buffer.Length, out m_iBytesRead);
    
                return ByteArrayToStructure<T>(buffer);
            }
    
            public static byte[] ReadMemory(int offset, int size) {
                var buffer = new byte[size];
    
                Imports.NtReadVirtualMemory((int) m_iProcessHandle, offset, buffer, size, out m_iBytesRead);
    
                return buffer;
            }
    
            public static float[] ReadMatrix<T>(int Adress, int MatrixSize) where T : struct {
                var ByteSize = Marshal.SizeOf(typeof(T));
                var buffer = new byte[ByteSize * MatrixSize];
                Imports.NtReadVirtualMemory((int) m_iProcessHandle, Adress, buffer, buffer.Length, out m_iBytesRead);
    
                return ConvertToFloatArray(buffer);
            }
    
            public static int GetModuleAddress(string Name) {
                try {
                    foreach (ProcessModule ProcMod in m_iProcess.Modules)
                        if (Name == ProcMod.ModuleName)
                            return (int) ProcMod.BaseAddress;
                }
                catch {
                }
    
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Cannot find - " + Name + " | Check file extension.");
                Console.ResetColor();
    
                return -1;
            }
    
            #region Other
    
            internal struct Flags {
                public const int PROCESS_VM_OPERATION = 0x0008;
                public const int PROCESS_VM_READ = 0x0010;
                public const int PROCESS_VM_WRITE = 0x0020;
            }
    
            #endregion
    
            #region Conversion
    
            public static float[] ConvertToFloatArray(byte[] bytes) {
                if (bytes.Length % 4 != 0)
                    throw new ArgumentException();
    
                var floats = new float[bytes.Length / 4];
    
                for (var i = 0; i < floats.Length; i++)
                    floats[i] = BitConverter.ToSingle(bytes, i * 4);
    
                return floats;
            }
    
            private static T ByteArrayToStructure<T>(byte[] bytes) where T : struct {
                var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
                try {
                    return (T) Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
                }
                finally {
                    handle.Free();
                }
            }
    
            private static byte[] StructureToByteArray(object obj) {
                var length = Marshal.SizeOf(obj);
    
                var array = new byte[length];
    
                var pointer = Marshal.AllocHGlobal(length);
    
                Marshal.StructureToPtr(obj, pointer, true);
                Marshal.Copy(pointer, array, 0, length);
                Marshal.FreeHGlobal(pointer);
    
                return array;
            }
    
            #endregion
        }
    }
