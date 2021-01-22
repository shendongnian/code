    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication1 {
        class Program {
            private struct MEMORY_BASIC_INFORMATION {
                public uint BaseAddress;
                public uint AllocationBase;
                public uint AllocationProtect;
                public uint RegionSize;
                public uint State;
                public uint Protect;
                public uint Type;
            }
            private const uint STACK_RESERVED_SPACE = 4096 * 16;
            [DllImport("kernel32.dll")]
            private static extern int VirtualQuery(
                IntPtr                          lpAddress,
                ref MEMORY_BASIC_INFORMATION    lpBuffer,
                int                             dwLength);
            private unsafe static uint EstimatedRemainingStackBytes() {
                MEMORY_BASIC_INFORMATION    stackInfo   = new MEMORY_BASIC_INFORMATION();
                IntPtr                      currentAddr = new IntPtr((uint) &stackInfo - 4096);
                VirtualQuery(currentAddr, ref stackInfo, sizeof(MEMORY_BASIC_INFORMATION));
                return (uint) currentAddr.ToInt64() - stackInfo.AllocationBase - STACK_RESERVED_SPACE;
            }
            static void sampleRecursiveMethod(int remainingIterations) {
                if (remainingIterations <= 0) { return; }
                Console.WriteLine(EstimatedRemainingStackBytes());
                sampleRecursiveMethod(remainingIterations - 1);
            }
            static void Main(string[] args) {
                sampleRecursiveMethod(100);
                Console.ReadLine();
            }
        }
    }
