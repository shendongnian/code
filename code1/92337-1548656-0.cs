    Imports System.Threading
    Public Class AlarmClock
        Public startTime As Integer = TimeOfDay.Hour
        Public interval As Integer = 1
        Public Event SoundAlarm()
        Public Sub CheckTime()
            While TimeOfDay.Hour < startTime + interval
                Application.DoEvents()
            End While
            RaiseEvent SoundAlarm()
        End Sub
        Public Sub StartClock()
            Dim clockthread As Thread = New Thread(AddressOf CheckTime)
            clockthread.Start()
        End Sub
    End Class
