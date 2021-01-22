    using Microsoft.Win32.SafeHandles;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO.MemoryMappedFiles;
    using System.Runtime.InteropServices;
    using System.Text;
    namespace MMFilePathTest
    {
        static class Program
        {
            private static MemoryMappedFile GetMappedPhysicalFile()
            {
                return MemoryMappedFile.CreateFromFile("test.bin", System.IO.FileMode.Create, null, 4096);
            }
            private static MemoryMappedFile GetMappedAnonymousMemory()
            {
                /* The documentation errounously claims that mapName must not be null. Actually anonymous
                 * mappings are quite a normal thing on Windows, and is actually both safer and more secure
                 * if you don't have a need for a name for them anyways.
                 * (Reported as https://github.com/dotnet/docs/issues/5404)
                 * Using a name here gives the exact same results (assuming the name isn't already in use). */
                return MemoryMappedFile.CreateNew(null, 4096);
            }
            /* This can be changed to kernel32.dll / K32GetMappedFileNameW if compatibility with Windows Server 2008 and
             * earlier is not needed, but it is not clear what the gain of doing so is, see the remarks about
             * PSAPI_VERSION at https://msdn.microsoft.com/en-us/library/windows/desktop/ms683195(v=vs.85).aspx */
            [DllImport("Psapi.dll", EntryPoint = "GetMappedFileNameW", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
            private static extern int GetMappedFileName(
              SafeProcessHandle hProcess,
              SafeMemoryMappedViewHandle lpv,
              [Out] StringBuilder lpFilename,
              int nSize
            );
                
            /* Note that the SafeMemoryMappedViewHandle property of SafeMemoryMappedViewAccess and SafeMemoryMappedViewStream
             * is actually the address where the file is mapped */
            private static string GetPathWithGetMappedFileName(SafeMemoryMappedViewHandle memoryMappedViewHandle)
            {
                // The maximum path length in the NT kernel is 32,767 - memory is cheap nowadays so its not a problem 
                // to just allocate the maximum size of 32KB right away.
                StringBuilder filename = new StringBuilder(short.MaxValue);
                int len;
                len = GetMappedFileName(Process.GetCurrentProcess().SafeHandle, memoryMappedViewHandle, filename, short.MaxValue);
                if (len == 0)
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                filename.Length = len;
                return filename.ToString();
            }
            private static void PrintFileName(MemoryMappedFile memoryMappedFile)
            {
                try
                {
                    using (memoryMappedFile)
                    using (MemoryMappedViewAccessor va = memoryMappedFile.CreateViewAccessor())
                    {
                        string filename = GetPathWithGetMappedFileName(va.SafeMemoryMappedViewHandle);
                        Console.WriteLine(filename);
                    }
                }
                catch (Win32Exception e)
                {
                    Console.WriteLine("Error: 0x{0:X08}: {1}", e.NativeErrorCode, e.Message);
                }
            }
            static void Main(string[] args)
            {
                PrintFileName(GetMappedPhysicalFile());
                PrintFileName(GetMappedAnonymousMemory());
            }
        }
    }
