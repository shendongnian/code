    Public Class MyDateTimePicker 
        Inherits System.Windows.Forms.DateTimePicker
        Private _disabled_back_color As Color
        Private _image As Image
        Private _text_color As Color = Color.Black
    
        Public Sub New()
            MyBase.New()
            Me.SetStyle(ControlStyles.UserPaint, True)
            _disabled_back_color = Color.FromKnownColor(KnownColor.Control)
        End Sub
    
        ''' <summary>
        '''     Gets or sets the background color of the control
        ''' </summary>
        <Browsable(True)>
        Public Overrides Property BackColor() As Color
            Get
                Return MyBase.BackColor
            End Get
            Set
                MyBase.BackColor = Value
            End Set
        End Property
    
        ''' <summary>
        '''     Gets or sets the background color of the control when disabled
        ''' </summary>
        <Category("Appearance"), Description("The background color of the component when disabled")>
        <Browsable(True)>
        Public Property BackDisabledColor() As Color
            Get
                Return _disabled_back_color
            End Get
            Set
                _disabled_back_color = Value
            End Set
        End Property
    
        ''' <summary>
        '''     Gets or sets the Image next to the dropdownbutton
        ''' </summary>
        <Category("Appearance"),
        Description("Get or Set the small Image next to the dropdownbutton")>
        Public Property Image() As Image
            Get
                Return _image
            End Get
            Set(ByVal Value As Image)
                _image = Value
                Invalidate()
            End Set
        End Property
    
        ''' <summary>
        '''     Gets or sets the text color when calendar is not visible
        ''' </summary>
        <Category("Appearance")>
        Public Property TextColor As Color
            Get
                Return _text_color
            End Get
            Set(value As Color)
                _text_color = value
            End Set
        End Property
    
    
        Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
            Dim g As Graphics = Me.CreateGraphics()
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
    
            'Dropdownbutton rectangle
            Dim ddb_rect As New Rectangle(ClientRectangle.Width - 17, 0, 17, ClientRectangle.Height)
            'Background brush
            Dim bb As Brush
    
            Dim visual_state As ComboBoxState
    
            'When enabled the brush is set to Backcolor, 
            'otherwise to color stored in _disabled_back_Color
            If Me.Enabled Then
                bb = New SolidBrush(Me.BackColor)
                visual_state = ComboBoxState.Normal
            Else
                bb = New SolidBrush(Me._disabled_back_color)
                visual_state = ComboBoxState.Disabled
            End If
    
            'Filling the background
            g.FillRectangle(bb, 0, 0, ClientRectangle.Width, ClientRectangle.Height)
    
            'Drawing the datetime text
            g.DrawString(Me.Text, Me.Font, New SolidBrush(TextColor), 5, 2)
    
            'Drawing icon
            If Not _image Is Nothing Then
                Dim im_rect As New Rectangle(ClientRectangle.Width - 40, 4, ClientRectangle.Height - 8, ClientRectangle.Height - 8)
                g.DrawImage(_image, im_rect)
            End If
    
            'Drawing the dropdownbutton using ComboBoxRenderer
            ComboBoxRenderer.DrawDropDownButton(g, ddb_rect, visual_state)
    
            g.Dispose()
            bb.Dispose()
        End Sub
    End Class
