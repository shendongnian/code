    'QueAPIExport QueErrT16 QueCreatePoint( const QuePointType* point, QuePointHandle* handle );'
    'QueAPIExport QueErrT16 QueClosePoint( QuePointHandle point );'
    <DllImport("QueAPI.dll")> _
    Private Shared Function QueCreatePoint(ByRef point As QuePointType, ByRef handle As Integer) As QueErrT16
    End Function
    <DllImport("QueAPI.dll")> _
    Private Shared Function QueRouteToPoint(ByVal point As Integer) As QueErrT16
    End Function
    '-- QueErrT16 ----------'
    'typedef uint16 QueErrT16; enum { ... }'
    Public Enum QueErrT16 As Short
        blah
    End Enum
    '-- QuePointType ----------'
    'typedef struct { char id[25]; QueSymbolT16 smbl; QuePositionDataType posn; } QuePointType;'
    
    'Remeber to initialize the id array.'
    Public Structure QuePointType
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=25)> Public id As Byte()
        Public smbl As QueSymbolT16
        Public posn As QuePositionDataType
    End Structure
    '-- QueSymbolT16 ----------'
    'typedef uint16 QueSymbolT16; enum { ... }'
    Public Enum QueSymbolT16 As Short
        blahblah
    End Enum
    '-- QuePositionDataType ----------'
    'typedef struct { sint32 lat; sint32 lon; float altMSL; } QuePositionDataType;'
    Public Structure QuePositionDataType
        Public lat As Integer
        Public lon As Integer
        Public altMSL As Single
    End Structure
    '-- QuePointHandle ----------'
    'typedef uint32 QuePointHandle;'
    'In VB use Integer.'
