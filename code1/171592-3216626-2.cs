    namespace CPUID
    {
        using System;
        using System.Linq;
        using System.Reflection;
        using System.Runtime.InteropServices;
        using System.Text;
    
        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        public unsafe delegate void CPUID0Delegate(byte* buffer);
    
        [UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        public unsafe delegate void CPUID1Delegate(byte* buffer);
    
        [Flags]
        public enum AllocationType : uint
        {
            Commit = 0x1000,
            Reserve = 0x2000,
            Reset = 0x80000,
            LargePages = 0x20000000,
            Physical = 0x400000,
            TopDown = 0x100000,
            WriteWatch = 0x200000
        }
    
        [Flags]
        public enum MemoryProtection : uint
        {
            Execute = 0x10,
            ExecuteRead = 0x20,
            ExecuteReadWrite = 0x40,
            ExecuteWriteCopy = 0x80,
            NoAccess = 0x01,
            ReadOnly = 0x02,
            ReadWrite = 0x04,
            WriteCopy = 0x08,
            GuartModifierflag = 0x100,
            NoCacheModifierflag = 0x200,
            WriteCombineModifierflag = 0x400
        }
    
        [Flags]
        public enum FreeType : uint
        {
            Decommit = 0x4000,
            Release = 0x8000
        }
    
        internal static class Program
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern IntPtr VirtualAlloc(
                IntPtr lpAddress,
                UIntPtr dwSize,
                AllocationType flAllocationType,
                MemoryProtection flProtect);
    
            [DllImport("kernel32")]
            private static extern bool VirtualFree(
                IntPtr lpAddress,
                uint dwSize,
                FreeType flFreeType);
    
            private static void Main()
            {
                Console.WriteLine("CPUID0: {0}", string.Join(", ", CPUID0().Select(x => x.ToString("X2")).ToArray()));
                Console.WriteLine("CPUID0: {0}", new string(ASCIIEncoding.ASCII.GetChars(CPUID0())));
                Console.WriteLine("CPUID1: {0}", string.Join(", ", CPUID1().Select(x => x.ToString("X2")).ToArray()));
                Console.ReadLine();
            }
    
            private static unsafe byte[] CPUID0()
            {
                byte[] buffer = new byte[12];
    
                if (IntPtr.Size == 4)
                {
                    IntPtr p = VirtualAlloc(
                        IntPtr.Zero,
                        new UIntPtr((uint)x86_CPUID0_INSNS.Length),
                        AllocationType.Commit | AllocationType.Reserve,
                        MemoryProtection.ExecuteReadWrite);
                    try
                    {
                        Marshal.Copy(x86_CPUID0_INSNS, 0, p, x86_CPUID0_INSNS.Length);
    
                        CPUID0Delegate del = (CPUID0Delegate)Marshal.GetDelegateForFunctionPointer(p, typeof(CPUID0Delegate));
    
                        fixed (byte* newBuffer = &buffer[0])
                        {
                            del(newBuffer);
                        }
                    }
                    finally
                    {
                        VirtualFree(p, 0, FreeType.Release);
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    IntPtr p = VirtualAlloc(
                        IntPtr.Zero,
                        new UIntPtr((uint)x64_CPUID0_INSNS.Length),
                        AllocationType.Commit | AllocationType.Reserve,
                        MemoryProtection.ExecuteReadWrite);
                    try
                    {
                        Marshal.Copy(x64_CPUID0_INSNS, 0, p, x64_CPUID0_INSNS.Length);
    
                        CPUID0Delegate del = (CPUID0Delegate)Marshal.GetDelegateForFunctionPointer(p, typeof(CPUID0Delegate));
    
                        fixed (byte* newBuffer = &buffer[0])
                        {
                            del(newBuffer);
                        }
                    }
                    finally
                    {
                        VirtualFree(p, 0, FreeType.Release);
                    }
                }
    
                return buffer;
            }
    
            private static unsafe byte[] CPUID1()
            {
                byte[] buffer = new byte[12];
    
                if (IntPtr.Size == 4)
                {
                    IntPtr p = VirtualAlloc(
                        IntPtr.Zero,
                        new UIntPtr((uint)x86_CPUID1_INSNS.Length),
                        AllocationType.Commit | AllocationType.Reserve,
                        MemoryProtection.ExecuteReadWrite);
                    try
                    {
                        Marshal.Copy(x86_CPUID1_INSNS, 0, p, x86_CPUID1_INSNS.Length);
    
                        CPUID1Delegate del = (CPUID1Delegate)Marshal.GetDelegateForFunctionPointer(p, typeof(CPUID1Delegate));
    
                        fixed (byte* newBuffer = &buffer[0])
                        {
                            del(newBuffer);
                        }
                    }
                    finally
                    {
                        VirtualFree(p, 0, FreeType.Release);
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    IntPtr p = VirtualAlloc(
                        IntPtr.Zero,
                        new UIntPtr((uint)x64_CPUID1_INSNS.Length),
                        AllocationType.Commit | AllocationType.Reserve,
                        MemoryProtection.ExecuteReadWrite);
                    try
                    {
                        Marshal.Copy(x64_CPUID1_INSNS, 0, p, x64_CPUID1_INSNS.Length);
    
                        CPUID1Delegate del = (CPUID1Delegate)Marshal.GetDelegateForFunctionPointer(p, typeof(CPUID1Delegate));
    
                        fixed (byte* newBuffer = &buffer[0])
                        {
                            del(newBuffer);
                        }
                    }
                    finally
                    {
                        VirtualFree(p, 0, FreeType.Release);
                    }
                }
    
                return buffer;
            }
    
            #region ASM
            private static byte[] x86_CPUID0_INSNS = new byte[]
                {
                    0x53,                      // push   %ebx
                    0x31, 0xc0,                // xor    %eax,%eax
                    0x0f, 0xa2,                // cpuid
                    0x8b, 0x44, 0x24, 0x08,    // mov    0x8(%esp),%eax
                    0x89, 0x18,                // mov    %ebx,0x0(%eax)
                    0x89, 0x50, 0x04,          // mov    %edx,0x4(%eax)
                    0x89, 0x48, 0x08,          // mov    %ecx,0x8(%eax)
                    0x5b,                      // pop    %ebx
                    0xc3                       // ret
                };
    
            private static byte[] x86_CPUID1_INSNS = new byte[]
                {
                    0x53,                   // push   %ebx
                    0x31, 0xc0,             // xor    %eax,%eax
                    0x40,                   // inc    %eax
                    0x0f, 0xa2,             // cpuid
                    0x5b,                   // pop    %ebx
                    0xc3                    // ret
                };
    
            private static byte[] x64_CPUID0_INSNS = new byte[]
                {
                    0x49, 0x89, 0xd8,       // mov    %rbx,%r8
                    0x49, 0x89, 0xc9,       // mov    %rcx,%r9
                    0x48, 0x31, 0xc0,       // xor    %rax,%rax
                    0x0f, 0xa2,             // cpuid
                    0x4c, 0x89, 0xc8,       // mov    %r9,%rax
                    0x89, 0x18,             // mov    %ebx,0x0(%rax)
                    0x89, 0x50, 0x04,       // mov    %edx,0x4(%rax)
                    0x89, 0x48, 0x08,       // mov    %ecx,0x8(%rax)
                    0x4c, 0x89, 0xc3,       // mov    %r8,%rbx
                    0xc3                    // retq
                };
    
            private static byte[] x64_CPUID1_INSNS = new byte[]
                {
                    0x53,                     // push   %rbx
                    0x48, 0x31, 0xc0,         // xor    %rax,%rax
                    0x48, 0xff, 0xc0,         // inc    %rax
                    0x0f, 0xa2,               // cpuid
                    0x5b,                     // pop    %rbx
                    0xc3                      // retq
                };
            #endregion
        }
    }
