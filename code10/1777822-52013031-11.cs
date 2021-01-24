    Imports System
    Imports System.Runtime.InteropServices
    
    Public Class CoreAudio
        Friend Enum EDataFlow
            eRender
            eCapture
            eAll
            EDataFlow_enum_count
        End Enum
        Friend Enum ERole
            eConsole
            eMultimedia
            eCommunications
            ERole_enum_count
        End Enum
        <Flags>
        Friend Enum CLSCTX As UInteger
            CLSCTX_INPROC_SERVER = &H1
            CLSCTX_INPROC_HANDLER = &H2
            CLSCTX_LOCAL_SERVER = &H4
            CLSCTX_INPROC_SERVER16 = &H8
            CLSCTX_REMOTE_SERVER = &H10
            CLSCTX_INPROC_HANDLER16 = &H20
            CLSCTX_RESERVED1 = &H40
            CLSCTX_RESERVED2 = &H80
            CLSCTX_RESERVED3 = &H100
            CLSCTX_RESERVED4 = &H200
            CLSCTX_NO_CODE_DOWNLOAD = &H400
            CLSCTX_RESERVED5 = &H800
            CLSCTX_NO_CUSTOM_MARSHAL = &H1000
            CLSCTX_ENABLE_CODE_DOWNLOAD = &H2000
            CLSCTX_NO_FAILURE_LOG = &H4000
            CLSCTX_DISABLE_AAA = &H8000
            CLSCTX_ENABLE_AAA = &H10000
            CLSCTX_FROM_DEFAULT_CONTEXT = &H20000
            CLSCTX_ACTIVATE_32_BIT_SERVER = &H40000
            CLSCTX_ACTIVATE_64_BIT_SERVER = &H80000
            CLSCTX_INPROC = CLSCTX_INPROC_SERVER Or CLSCTX_INPROC_HANDLER
            CLSCTX_SERVER = CLSCTX_INPROC_SERVER Or CLSCTX_LOCAL_SERVER Or CLSCTX_REMOTE_SERVER
            CLSCTX_ALL = CLSCTX_SERVER Or CLSCTX_INPROC_HANDLER
        End Enum
        <ComImport, Guid("BCDE0395-E52F-467C-8E3D-C4579291692E")>
        Friend Class MMDeviceEnumeratorComObject
        End Class
        <ComImport, Guid("A95664D2-9614-4F35-A746-DE8DB63617E6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
        Friend Interface IMMDeviceEnumerator
            Function NotImpl1() As Integer
            Function GetDefaultAudioEndpoint(dataFlow As EDataFlow, role As ERole, ByRef ppDevice As IMMDevice) As Integer
        End Interface
        <ComImport, Guid("D666063F-1587-4E43-81F1-B948E807363F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
        Friend Interface IMMDevice
            Function Activate(ByRef iid As Guid, dwClsCtx As CLSCTX, pActivationParams As IntPtr, <Out> ByRef ppInterface As IAudioEndpointVolume) As Integer
        End Interface
        <ComImport, Guid("5CDF2C82-841E-4546-9722-0CF74078229A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
        Friend Interface IAudioEndpointVolume
            Function RegisterControlChangeNotify() As Integer
            Function UnregisterControlChangeNotify() As Integer
            Function GetChannelCount(ByRef channelCount As Integer) As Integer
            Function SetMasterVolumeLevel() As Integer
            Function SetMasterVolumeLevelScalar(level As Single, eventContext As Guid) As Integer
            Function GetMasterVolumeLevel(<Out> ByRef level As Single) As Integer
            Function GetMasterVolumeLevelScalar(<Out> ByRef level As Single) As Integer
            Function SetChannelVolumeLevel(channelNumber As Integer, level As Single, eventContext As Guid) As Integer
            Function SetChannelVolumeLevelScalar(channelNumber As Integer, level As Single, eventContext As Guid) As Integer
            Function GetChannelVolumeLevel(channelNumber As Integer, <Out> ByRef level As Single) As Integer
            Function GetChannelVolumeLevelScalar(channelNumber As Integer, <Out> ByRef level As Single) As Integer
            Function SetMute(<MarshalAs(UnmanagedType.Bool)> isMuted As Boolean, eventContext As Guid) As Integer
            Function GetMute(<Out> ByRef isMuted As Boolean) As Integer
            Function GetVolumeStepInfo(<Out> ByRef pnStep As Integer, ByRef pnStepCount As Integer) As Integer
            Function VolumeStepUp(eventContext As Guid) As Integer
            Function VolumeStepDown(eventContext As Guid) As Integer
            Function QueryHardwareSupport(<Out> ByRef hardwareSupportMask As Integer) As Integer
            Function GetVolumeRange(<Out> ByRef volumeMin As Single, <Out> ByRef volumeMax As Single, <Out> ByRef volumeStep As Single) As Integer
        End Interface
        Public Function IsMuted() As Integer
            Dim masterVol As IAudioEndpointVolume = Nothing
            Try
                masterVol = GetMasterVolumeObject()
                If masterVol Is Nothing Then
                    Return -1
                End If
                Dim isAudioMuted As Boolean
                masterVol.GetMute(isAudioMuted)
                Return Convert.ToInt32(isAudioMuted)
            Finally
                If masterVol IsNot Nothing Then
                    Marshal.ReleaseComObject(masterVol)
                End If
            End Try
        End Function
        Public Sub SetMute(IsMute As Boolean)
            Dim masterVol As IAudioEndpointVolume = Nothing
            Try
                masterVol = GetMasterVolumeObject()
                masterVol.SetMute(IsMute, Guid.Empty)
            Finally
                If masterVol IsNot Nothing Then
                    Marshal.ReleaseComObject(masterVol)
                End If
            End Try
        End Sub
        Public Function GetVolume() As Integer
            Dim fVolume As Single
            Dim masterVol As IAudioEndpointVolume = Nothing
            Try
                masterVol = GetMasterVolumeObject()
                masterVol.GetMasterVolumeLevelScalar(fVolume)
                Return CType(fVolume * 100, Integer)
            Finally
                Marshal.ReleaseComObject(masterVol)
            End Try
        End Function
        Public Sub SetVolume(Volume As Integer)
            Volume = Math.Max(Math.Min(Volume, 100), 0)
            Dim masterVol As IAudioEndpointVolume = Nothing
            Try
                masterVol = GetMasterVolumeObject()
                masterVol.SetMasterVolumeLevelScalar((CType(Volume, Single) / 100), Guid.Empty)
            Finally
                Marshal.ReleaseComObject(masterVol)
            End Try
        End Sub
        Public Sub VolumeUp()
            Dim masterVol As IAudioEndpointVolume = Nothing
            Try
                masterVol = GetMasterVolumeObject()
                masterVol.VolumeStepUp(Guid.Empty)
            Finally
                Marshal.ReleaseComObject(masterVol)
            End Try
        End Sub
        Public Sub VolumeDown()
            Dim masterVol As IAudioEndpointVolume = Nothing
            Try
                masterVol = GetMasterVolumeObject()
                masterVol.VolumeStepDown(Guid.Empty)
            Finally
                Marshal.ReleaseComObject(masterVol)
            End Try
        End Sub
        Friend Function GetMasterVolumeObject() As IAudioEndpointVolume
            Dim deviceEnumerator As IMMDeviceEnumerator = Nothing
            Dim MediaDevice As IMMDevice = Nothing
            Try
                deviceEnumerator = TryCast(New MMDeviceEnumeratorComObject(), IMMDeviceEnumerator)
                deviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia, MediaDevice)
                Dim EndPointVolID As Guid = GetType(IAudioEndpointVolume).GUID
                Dim ppEndpoint As IAudioEndpointVolume = Nothing
                MediaDevice.Activate(EndPointVolID, CLSCTX.CLSCTX_ALL, IntPtr.Zero, ppEndpoint)
                Return ppEndpoint
            Finally
                Marshal.ReleaseComObject(deviceEnumerator)
                Marshal.ReleaseComObject(MediaDevice)
            End Try
        End Function
    End Class
