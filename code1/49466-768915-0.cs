    '  A custom MessageBox class
    '  Written to allow custom button text, specifically to allow for bilingual messageboxes
    '
    Public Class CustomMessageBox
    
      'Variables
      Private _btn1Return As DialogResult
      Private _btn2Return As DialogResult
      Private _btn3Return As DialogResult
    
      'Enumerate system icons
      Enum SystemIcons
        ErrorIcon = 1
        WarningIcon = 2
        QuestionIcon = 3
        InformationIcon = 4
      End Enum
    
      'Enumerate possible button combinations
      Enum ButtonTypes
        YesNo = 1
        YesNoCancel = 2
        Ok = 3
        OkCancel = 4
      End Enum
    
      'Enumerate possible default buttons
      Enum DefaultButton
        Button1 = 1
        Button2 = 2
        Button3 = 3
      End Enum
    
    
    #Region "Constructor"
      'Constructor
      Public Sub New(ByVal text As String, ByVal caption As String, ByVal buttons As ButtonTypes, ByVal icon As SystemIcons, ByVal defaultButton As DefaultButton)
        InitializeComponent()
        Me.Text = caption
        Me.msgBoxText.Text = text
        SetupIcon(icon)
        SetupButtons(buttons, defaultButton)
      End Sub
    #End Region
    
    #Region "Functions"
      'Set text and return values of all buttons.  Also set focus to default button.
      Private Sub SetupButtons(ByVal buttons As Integer, ByVal defaultButton As Integer)
        Select Case buttons
          Case 1
            msgBoxButton1.Text = My.Resources.Caption_Yes
            _btn1Return = Windows.Forms.DialogResult.Yes
            msgBoxButton2.Text = My.Resources.Caption_No
            _btn2Return = Windows.Forms.DialogResult.No
            msgBoxButton3.Visible = False
          Case 2
            msgBoxButton1.Text = My.Resources.Caption_Yes
            _btn1Return = Windows.Forms.DialogResult.Yes
            msgBoxButton2.Text = My.Resources.Caption_No
            _btn2Return = Windows.Forms.DialogResult.No
            msgBoxButton3.Text = My.Resources.Caption_Cancel
            _btn3Return = Windows.Forms.DialogResult.Cancel
          Case 3
            msgBoxButton1.Text = My.Resources.Caption_OK
            _btn1Return = Windows.Forms.DialogResult.OK
            msgBoxButton2.Visible = False
            msgBoxButton3.Visible = False
          Case 4
            msgBoxButton1.Text = My.Resources.Caption_OK
            _btn1Return = Windows.Forms.DialogResult.OK
            msgBoxButton2.Text = My.Resources.Caption_Cancel
            _btn2Return = Windows.Forms.DialogResult.Cancel
            msgBoxButton3.Visible = False
        End Select
    
        'Set focus to specified default button
        Select Case defaultButton
          Case 1
            msgBoxButton1.Focus()
          Case 2
            msgBoxButton2.Focus()
          Case 3
            msgBoxButton3.Focus()
        End Select
    
      End Sub
    
      'Display specified icon
      Private Sub SetupIcon(ByVal iconValue As Integer)
        Dim icon As Icon = Nothing
        Select Case iconValue
          Case 1
            icon = System.Drawing.SystemIcons.Error
          Case 2
            icon = System.Drawing.SystemIcons.Warning
          Case 3
            icon = System.Drawing.SystemIcons.Question
          Case 4
            icon = System.Drawing.SystemIcons.Information
        End Select
    
        Me.msgBoxIcon.Image = icon.ToBitmap
      End Sub
    #End Region
    
    #Region "Events"
      'Set return value when button is clicked.
      Private Sub msgBoxButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msgBoxButton1.Click
        Me.DialogResult = _btn1Return
        Me.Close()
      End Sub
    
      'Set return value when button is clicked.
      Private Sub msgBoxButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msgBoxButton2.Click
        Me.DialogResult = _btn2Return
        Me.Close()
      End Sub
    
      'Set return value when button is clicked.
      Private Sub msgBoxButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msgBoxButton3.Click
        Me.DialogResult = _btn3Return
        Me.Close()
      End Sub
    #End Region
    
    End Class
