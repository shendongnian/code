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
    
        <ComImport, Guid("BCDE0395-E52F-467C-8E3D-C4579291692E")>
        Class MMDeviceEnumeratorComObject
        End Class
    
        <ComImport, Guid("A95664D2-9614-4F35-A746-DE8DB63617E6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
        Friend Interface IMMDeviceEnumerator
            Function NotImpl1() As Integer
            Function GetDefaultAudioEndpoint(dataFlow As EDataFlow, role As ERole, ByRef ppDevice As IMMDevice) As Integer
        End Interface
    
        <ComImport, Guid("D666063F-1587-4E43-81F1-B948E807363F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
        Friend Interface IMMDevice
            Function Activate(ByRef iid As Guid, dwClsCtx As Integer, pActivationParams As IntPtr, <MarshalAs(UnmanagedType.IUnknown)> ByRef ppInterface As Object) As Integer
        End Interface
    
        <ComImport, Guid("5CDF2C82-841E-4546-9722-0CF74078229A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
        Public Interface IAudioEndpointVolume
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
    
        Private Function GetMasterVolumeObject() As IAudioEndpointVolume
            Dim deviceEnumerator As IMMDeviceEnumerator = Nothing
            Dim speakers As IMMDevice = Nothing
            Try
                deviceEnumerator = CType(New MMDeviceEnumeratorComObject(), IMMDeviceEnumerator)
                deviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia, speakers)
    
                Dim IID_IAudioEndpointVolume As Guid = GetType(IAudioEndpointVolume).GUID
                Dim o As Object
                speakers.Activate(IID_IAudioEndpointVolume, 0, IntPtr.Zero, o)
                Dim masterVol As IAudioEndpointVolume = CType(o, IAudioEndpointVolume)
    
                Return masterVol
            Finally
                If speakers IsNot Nothing Then
                    Marshal.ReleaseComObject(speakers)
                End If
                If deviceEnumerator IsNot Nothing Then
                    Marshal.ReleaseComObject(deviceEnumerator)
                End If
            End Try
        End Function
    
    End Class
