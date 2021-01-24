      <StructLayout(LayoutKind.Sequential, Pack:=1)>
    Public Structure SGDeviceInfoParam
        Private Const SGDEV_SN_LEN As Integer = 15
        ' Device Serial Number Length
        Public DeviceID As UInt32
        ' Device Serial Number, Length of SN = 15
        Public ComPort As UInt32
        ' Parallel device=>PP address, USB device=>USB(0x3BC+1)
        Public ComSpeed As UInt32
        ' Parallel device=>PP mode, USB device=>0 
        Public ImageWidth As UInt32
        ' Image Width
        Public ImageHeight As UInt32
        ' Image Height
        Public Contrast As UInt32
        ' 0 ~ 100
        Public Brightness As UInt32
        ' 0 ~ 100
        Public Gain As UInt32
        ' Dependent on each device
        Public ImageDPI As UInt32
        ' DPI
        Public FWVersion As UInt32
    End Structure
