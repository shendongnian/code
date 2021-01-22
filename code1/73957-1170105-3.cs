    [DllImport("user32.dll", CharSet=CharSet.Unicode, SetLastError=true)]
    public static extern int DrawTextExW( HandleRef hDC
                                         ,string lpszString
                                         ,int nCount
                                         ,ref RECT lpRect
                                         ,int nFormat
                                         ,[In, Out] DRAWTEXTPARAMS lpDTParams);
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
     {
       public int left;
       public int top;
       public int right;
       public int bottom;
     }
    [StructLayout(LayoutKind.Sequential)]
    public class DRAWTEXTPARAMS
    {
      public int iTabLength;
      public int iLeftMargin;
      public int iRightMargin;
      public int uiLengthDrawn;
    }
