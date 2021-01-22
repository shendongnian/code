    using System;
    using System.Runtime.InteropServices;
 
    public class WorkArea
    {
      [System.Runtime.InteropServices.DllImport("user32.dll",  EntryPoint="SystemParametersInfoA")]
      private static extern Int32 SystemParametersInfo(Int32 uAction, Int32 uParam, IntPtr lpvParam, Int32 fuWinIni);
      private const Int32 SPI_SETWORKAREA = 47;
      public WorkArea(Int32 Left,Int32 Right,Int32 Top,Int32 Bottom)
      {
        _WorkArea.Left = Left;
        _WorkArea.Top = Top;
        _WorkArea.Bottom = Bottom;
        _WorkArea.Right = Right;
      }
      public struct RECT
      {
        public Int32 Left;
        public Int32 Right;
        public Int32 Top;
        public Int32 Bottom;
      }
      private RECT _WorkArea;
      public void SetWorkingArea()
      {
        IntPtr ptr = IntPtr.Zero;
        ptr = Marshal.AllocHGlobal(Marshal.SizeOf(_WorkArea));
        Marshal.StructureToPtr(_WorkArea,ptr,false);
        int i = SystemParametersInfo(SPI_SETWORKAREA,0,ptr,0);
      }
    }
