    using System;
    using Microsoft.Win32.SafeHandles;
    using System.Runtime.InteropServices;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Path = System.IO.Path;
    
    class Program {
    
      static void Main() {
    
        string sTestFile = Path.Combine(Path.GetDirectoryName(
         Application.ExecutablePath), "Test.txt");
    
        // test reading a file
        WinApiFile File = new WinApiFile(sTestFile,
         WinApiFile.DesiredAccess.GENERIC_READ);
        byte[] aBuffer = new byte[1000];
        uint cbRead = File.Read(aBuffer, 1000);
        File.Close();
    
        // Test writing the file
        File.Open(WinApiFile.DesiredAccess.GENERIC_WRITE);
        // write the time to a 10 byte offset in the file
        // conver the date time to byte array
        int i = 0;
        foreach (var ch in DateTime.Now.ToString()) 
          aBuffer[i++] = (byte)ch;
        // now write it out
        File.MoveFilePointer(10);  // 10 byte offset
        File.Write(aBuffer, (uint)i);  // write the time
        File.Dispose();
      }
    }
    
    public class WinApiFile : IDisposable {
    
      /* ---------------------------------------------------------
       * private members
       * ------------------------------------------------------ */
      private SafeFileHandle _hFile = null;
      private string _sFileName = "";
      private bool _fDisposed;
    
      /* ---------------------------------------------------------
       * properties
       * ------------------------------------------------------ */
      public bool IsOpen { get { return (_hFile != null); } }
      public SafeFileHandle Handle { get { return _hFile; } }
      public string FileName {
        get { return _sFileName; }
        set {
          _sFileName = (value ?? "").Trim();
          if (_sFileName.Length == 0)
            CloseHandle(_hFile);
        }
      }
      public int FileLength {
        get {
          return (_hFile != null) ? (int)GetFileSize(_hFile,
           IntPtr.Zero) : 0;
        }
        set {
          if (_hFile == null)
            return;
          MoveFilePointer(value, MoveMethod.FILE_BEGIN);
          if (!SetEndOfFile(_hFile))
            ThrowLastWin32Err();
        }
      }
    
      /* ---------------------------------------------------------
       * Constructors
       * ------------------------------------------------------ */
    
      public WinApiFile(string sFileName,
       DesiredAccess fDesiredAccess) {
        FileName = sFileName;
        Open(fDesiredAccess);
      }
      public WinApiFile(string sFileName,
       DesiredAccess fDesiredAccess,
       CreationDisposition fCreationDisposition) {
        FileName = sFileName;
        Open(fDesiredAccess, fCreationDisposition);
      }
    
      /* ---------------------------------------------------------
       * Open/Close
       * ------------------------------------------------------ */
    
      public void Open(
       DesiredAccess fDesiredAccess) {
        Open(fDesiredAccess, CreationDisposition.OPEN_EXISTING);
      }
    
      public void Open(
       DesiredAccess fDesiredAccess,
       CreationDisposition fCreationDisposition) {
        ShareMode fShareMode;
        if (fDesiredAccess == DesiredAccess.GENERIC_READ) {
          fShareMode = ShareMode.FILE_SHARE_READ;
        } else {
          fShareMode = ShareMode.FILE_SHARE_NONE;
        }
        Open(fDesiredAccess, fShareMode, fCreationDisposition, 0);
      }
    
      public void Open(
       DesiredAccess fDesiredAccess, 
       ShareMode fShareMode, 
       CreationDisposition fCreationDisposition, 
       FlagsAndAttributes fFlagsAndAttributes) {
    
        if (_sFileName.Length == 0)
          throw new ArgumentNullException("FileName");
        _hFile = CreateFile(_sFileName, fDesiredAccess, fShareMode, 
         IntPtr.Zero, fCreationDisposition, fFlagsAndAttributes, 
         IntPtr.Zero);
        if (_hFile.IsInvalid) {
          _hFile = null;
          ThrowLastWin32Err();
        }
        _fDisposed = false;
    
      }
    
      public void Close() {
        if (_hFile == null)
          return;
        _hFile.Close();
        _hFile = null;
        _fDisposed = true;
      }
    
      /* ---------------------------------------------------------
       * Move file pointer 
       * ------------------------------------------------------ */
    
      public void MoveFilePointer(int cbToMove) {
        MoveFilePointer(cbToMove, MoveMethod.FILE_CURRENT);
      }
    
      public void MoveFilePointer(int cbToMove, 
       MoveMethod fMoveMethod) {
        if (_hFile != null)
          if (SetFilePointer(_hFile, cbToMove, IntPtr.Zero, 
           fMoveMethod) == INVALID_SET_FILE_POINTER)
            ThrowLastWin32Err();
      }
    
      public int FilePointer {
        get {
          return (_hFile != null) ? (int)SetFilePointer(_hFile, 0, 
           IntPtr.Zero, MoveMethod.FILE_CURRENT) : 0;
        }
        set {
          MoveFilePointer(value);
        }
      }
    
      /* ---------------------------------------------------------
       * Read and Write
       * ------------------------------------------------------ */
    
      public uint Read(byte[] buffer, uint cbToRead) {
        // returns bytes read
        uint cbThatWereRead = 0;
        if (!ReadFile(_hFile, buffer, cbToRead, 
         ref cbThatWereRead, IntPtr.Zero))
          ThrowLastWin32Err();
        return cbThatWereRead;
      }
    
      public uint Write(byte[] buffer, uint cbToWrite) {
        // returns bytes read
        uint cbThatWereWritten = 0;
        if (!WriteFile(_hFile, buffer, cbToWrite, 
         ref cbThatWereWritten, IntPtr.Zero))
          ThrowLastWin32Err();
        return cbThatWereWritten;
      }
    
      /* ---------------------------------------------------------
       * IDisposable Interface
       * ------------------------------------------------------ */
      public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
      }
    
      protected virtual void Dispose(bool fDisposing) {
        if (!_fDisposed) {
          if (fDisposing) {
            if (_hFile != null)
              _hFile.Dispose();
            _fDisposed = true;
          }
        }
      }
    
      ~WinApiFile() {
        Dispose(false);
      }
    
      /* ---------------------------------------------------------
       * WINAPI STUFF
       * ------------------------------------------------------ */
    
      private void ThrowLastWin32Err() {
        Marshal.ThrowExceptionForHR(
         Marshal.GetHRForLastWin32Error());
      }
    
      [Flags]
      public enum DesiredAccess : uint {
        GENERIC_READ = 0x80000000,
        GENERIC_WRITE = 0x40000000
      }
      [Flags]
      public enum ShareMode : uint {
        FILE_SHARE_NONE = 0x0,
        FILE_SHARE_READ = 0x1,
        FILE_SHARE_WRITE = 0x2,
        FILE_SHARE_DELETE = 0x4,
    
      }
      public enum MoveMethod : uint {
        FILE_BEGIN = 0,
        FILE_CURRENT = 1,
        FILE_END = 2
      }
      public enum CreationDisposition : uint {
        CREATE_NEW = 1,
        CREATE_ALWAYS = 2,
        OPEN_EXISTING = 3,
        OPEN_ALWAYS = 4,
        TRUNCATE_EXSTING = 5
      }
      [Flags]
      public enum FlagsAndAttributes : uint {
        FILE_ATTRIBUTES_ARCHIVE = 0x20,
        FILE_ATTRIBUTE_HIDDEN = 0x2,
        FILE_ATTRIBUTE_NORMAL = 0x80,
        FILE_ATTRIBUTE_OFFLINE = 0x1000,
        FILE_ATTRIBUTE_READONLY = 0x1,
        FILE_ATTRIBUTE_SYSTEM = 0x4,
        FILE_ATTRIBUTE_TEMPORARY = 0x100,
        FILE_FLAG_WRITE_THROUGH = 0x80000000,
        FILE_FLAG_OVERLAPPED = 0x40000000,
        FILE_FLAG_NO_BUFFERING = 0x20000000,
        FILE_FLAG_RANDOM_ACCESS = 0x10000000,
        FILE_FLAG_SEQUENTIAL_SCAN = 0x8000000,
        FILE_FLAG_DELETE_ON = 0x4000000,
        FILE_FLAG_POSIX_SEMANTICS = 0x1000000,
        FILE_FLAG_OPEN_REPARSE_POINT = 0x200000,
        FILE_FLAG_OPEN_NO_CALL = 0x100000
      }
    
      public const uint INVALID_HANDLE_VALUE = 0xFFFFFFFF;
      public const uint INVALID_SET_FILE_POINTER = 0xFFFFFFFF;
      // Use interop to call the CreateFile function.
      // For more information about CreateFile,
      // see the unmanaged MSDN reference library.
      [DllImport("kernel32.dll", SetLastError = true)]
      internal static extern SafeFileHandle CreateFile(
       string lpFileName,
       DesiredAccess dwDesiredAccess, 
       ShareMode dwShareMode, 
       IntPtr lpSecurityAttributes,
       CreationDisposition dwCreationDisposition, 
       FlagsAndAttributes dwFlagsAndAttributes,
       IntPtr hTemplateFile);
    
      [DllImport("kernel32", SetLastError = true)]
      internal static extern Int32 CloseHandle(
       SafeFileHandle hObject);
    
      [DllImport("kernel32", SetLastError = true)]
      internal static extern bool ReadFile(
       SafeFileHandle hFile, 
       Byte[] aBuffer,
       UInt32 cbToRead,
       ref UInt32 cbThatWereRead, 
       IntPtr pOverlapped);
    
      [DllImport("kernel32.dll", SetLastError = true)]
      internal static extern bool WriteFile(
       SafeFileHandle hFile, 
       Byte[] aBuffer,
       UInt32 cbToWrite, 
       ref UInt32 cbThatWereWritten, 
       IntPtr pOverlapped);
    
      [DllImport("kernel32.dll", SetLastError = true)]
      internal static extern UInt32 SetFilePointer(
       SafeFileHandle hFile,
       Int32 cbDistanceToMove, 
       IntPtr pDistanceToMoveHigh,
       MoveMethod fMoveMethod);
    
      [DllImport("kernel32.dll", SetLastError = true)]
      internal static extern bool SetEndOfFile(
       SafeFileHandle hFile);
    
      [DllImport("kernel32.dll", SetLastError = true)]
      internal static extern UInt32 GetFileSize(
       SafeFileHandle hFile, 
       IntPtr pFileSizeHigh);
    
    }
