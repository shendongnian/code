        // DbgHelpNet.h
    #pragma once
    
    #include <dbghelp.h>
    
    using namespace System;
    using namespace System;
    using namespace System::IO;
    using namespace System::Diagnostics;
    using namespace System::Runtime::InteropServices;
    using namespace System::Configuration;
    
    namespace DbgHelpNet {
    
     /// <summary>Defines the information density of the mini dump (see MINIDUMP_TYPE on MSDN)</summary>
     public enum class MiniDumpTypeEnumeration
     {
      MiniDumpNormal                         = 0x00000000,
      MiniDumpWithDataSegs                   = 0x00000001,
      MiniDumpWithFullMemory                 = 0x00000002,
      MiniDumpWithHandleData                 = 0x00000004,
      MiniDumpFilterMemory                   = 0x00000008,
      MiniDumpScanMemory                     = 0x00000010,
      MiniDumpWithUnloadedModules            = 0x00000020,
      MiniDumpWithIndirectlyReferencedMemory = 0x00000040,
      MiniDumpFilterModulePaths              = 0x00000080,
      MiniDumpWithProcessThreadData          = 0x00000100,
      MiniDumpWithPrivateReadWriteMemory     = 0x00000200,
      MiniDumpWithoutOptionalData            = 0x00000400,
      MiniDumpWithFullMemoryInfo             = 0x00000800,
      MiniDumpWithThreadInfo                 = 0x00001000,
      MiniDumpWithCodeSegs                   = 0x00002000,
      MiniDumpWithoutAuxiliaryState          = 0x00004000,
      MiniDumpWithFullAuxiliaryState         = 0x00008000,    
      MiniDumpWithPrivateWriteCopyMemory     = 0x00010000,
      MiniDumpIgnoreInaccessibleMemory       = 0x00020000,
      MiniDumpValidTypeFlags                 = 0x0000ffff,
     };
    
     public ref class MiniDumpWriteDump
     {
     public:
      static void MiniDumpWriteDump::WriteDump(String^ path);
      static void MiniDumpWriteDump::WriteDump(String^ path, IntPtr exceptionPointers, MiniDumpTypeEnumeration MiniDumpType);
     };
    }
