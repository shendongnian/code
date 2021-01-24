    Imports System.ComponentModel
    Partial Public Class C_PANEL
    Inherits Panel
    Private Const WS_EX_TRANSPARENT As Integer = &H20
    Public Sub NewP()
        SetStyle(ControlStyles.Opaque, True)
    End Sub
    Public Sub NewP(con As IContainer)
        con.Add(Me)
    End Sub
    Private iopacity As Integer = 50
    <DefaultValue(50)>
    Public Property Opacity() As Integer
        Get
            Return Me.iopacity
        End Get
        Set(value As Integer)
            If Value < 0 OrElse Value > 100 Then
                Throw New ArgumentException("value must be between 0 and 100")
            End If
            Me.iopacity = Value
        End Set
    End Property
    Protected Overrides ReadOnly Property CreateParams() _
              As CreateParams
        Get
            Dim cpar As CreateParams = MyBase.CreateParams
            cpar.ExStyle = cpar.ExStyle Or WS_EX_TRANSPARENT
            Return cpar
        End Get
    End Property
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Using brush = New SolidBrush(Color.FromArgb(Me.Opacity _
              * 255 / 100, Me.BackColor))
            e.Graphics.FillRectangle(brush, Me.ClientRectangle)
        End Using
        MyBase.OnPaint(e)
    End Sub
    End Class
