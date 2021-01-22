    Private Sub RaiseStreamVolumeNotification()
            Dim SVEA As New StreamVolumeEventArgs()
            SVEA.MaxSampleValues = CType(maxSamples.Clone(), Single())
            If Not StreamVolume Is Nothing Then
                StreamVolume(this, SVEA)
            End If
    End Sub
    
    Public Class StreamVolumeEventArgs Inheirits EventArgs
        Private _MaxSampleValues As Single()
        Public Property MaxSampleValues As Single()
            Get
                Return _MaxSampleValues
            End Get
            Set(value as Single())
                _MaxSampleValues = value
            End Set
        End Property
    End Class
