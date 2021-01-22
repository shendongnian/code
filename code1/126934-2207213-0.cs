    using System.Runtime.InteropServices;
    using System;
    using WinApi;
    
    [ Flags ]
    enum AllocationType
    {
    	| Commit = 0x1000
    }
    
    [ Flags ]
    enum ProcessAccess : int
    {
    	| VMOperation = 0x8
    	| VMRead      = 0x10
    	| VMWrite     = 0x20
    }
    
    [ Flags ]
    enum MemoryProtection
    {
    	| ReadWrite = 0x04
    }
    
    module WinApi
    {
    	[ DllImport("kernel32.dll") ]
    	public extern OpenProcess
    		( dwDesiredAccess : ProcessAccess
    		, bInheritHandle  : bool
    		, dwProcessId     : int
    		) : IntPtr;
    
    	[ DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true) ]
    	public extern VirtualAllocEx
    		( hProcess         : IntPtr
    		, lpAddress        : IntPtr
    		, dwSize           : uint
    		, flAllocationType : AllocationType
    		, flProtect        : MemoryProtection
    		) : IntPtr;
    
    	[ DllImport("kernel32.dll", SetLastError = true) ]
    	public extern WriteProcessMemory
    		( hProcess               : IntPtr
    		, lpBaseAddress          : IntPtr
    		, lpBuffer               : array[byte]
    		, nSize                  : uint
    		, lpNumberOfBytesWritten : out int
    		) : bool;
    }
    
    def data = System.Text.Encoding.Unicode.GetBytes("Hello World!\0");
    
    def process = OpenProcess
    	( dwDesiredAccess
    		= ProcessAccess.VMOperation
    		| ProcessAccess.VMRead
    		| ProcessAccess.VMWrite
    	, bInheritHandle  = false
    	, dwProcessId     = 0x00005394 // Notepad instance
    	);
    Console.WriteLine($"process: $process");
    
    def memory = VirtualAllocEx
    	( hProcess         = process
    	, lpAddress        = IntPtr.Zero
    	, dwSize           = data.Length :> uint
    	, flAllocationType = AllocationType.Commit
    	, flProtect        = MemoryProtection.ReadWrite
    	);
    Console.WriteLine($"memory: $memory");
    
    mutable bytesWritten;
    _ = WriteProcessMemory
    	( hProcess               = process
    	, lpBaseAddress          = memory
    	, lpBuffer               = data
    	, nSize                  = data.Length :> uint
    	, lpNumberOfBytesWritten = out bytesWritten
    	);
    Console.WriteLine($"bytesWritten: $bytesWritten");
