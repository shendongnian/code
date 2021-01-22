    Imports System
    Imports System.Windows.Forms
    Imports System.Drawing
    
    Public Class TransparentControl
        Inherits Control
    
        Private ReadOnly Local_Timer As Timer
        Private Local_Image As Image
    
        Public Sub New()
            SetStyle(ControlStyles.SupportsTransparentBackColor, True)
            BackColor = Color.Transparent
            Local_Timer = New Timer
            With Local_Timer
                .Interval = 50
                .Enabled = True
                .Start()
            End With
    
            AddHandler Local_Timer.Tick, AddressOf TimerOnClick
    
        End Sub
    
        Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
            Get
                Dim cp As CreateParams
                cp = MyBase.CreateParams
                cp.ExStyle = &H20
                Return cp
            End Get
        End Property
    
        Protected Overrides Sub OnMove(ByVal e As System.EventArgs)
            MyBase.OnMove(e)
            RecreateHandle()
        End Sub
    
        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
    
            If Local_Image IsNot Nothing Then _
                e.Graphics.DrawImage(Local_Image, New Rectangle(0, 0, (Width / 2) - (Local_Image.Width / 2), (Height / 2) - (Local_Image.Height / 2)))
    
        End Sub
    
        Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)
            ' DO NOT PAINT BACKGROUND
        End Sub
    
        ''' <summary>
        ''' Hack
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ReDraw()
            RecreateHandle()
        End Sub
    
        Private Sub TimerOnClick(ByVal sender As Object, ByVal e As System.EventArgs)
            RecreateHandle()
            Local_Timer.Stop()
    
        End Sub
    
        Public Property Image As Image
            Get
                Return Local_Image
            End Get
            Set(ByVal value As Image)
                Local_Image = value
                RecreateHandle()
            End Set
        End Property
    End Class
