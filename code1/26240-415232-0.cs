    <StructLayout (LayoutKind.Sequential, CharSet:=CharSet.Auto)> _
    Public Structure OSVERSIONINFO
        Public dwOSVersionInfoSize As Integer
        Public dwMajorVersion As Integer
        Public dwMinorVersion As Integer
        Public dwBuildNumber As Integer
        Public dwPlatformId As Integer
    
        <MarshalAs (UnmanagedType.ByValTStr, SizeConst:=128)> _
        Public szCSDVersion As String
    End Structure
