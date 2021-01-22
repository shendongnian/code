    Public Module Extension
        Private Sub ClearTextBox(ByVal T As TextBox)
            T.Clear()
        End Sub
    
        Private Sub ClearCheckBox(ByVal T As CheckBox)
            T.Checked = False
        End Sub
    
        Private Sub ClearListBox(ByVal T As ListBox)
            T.Items.Clear()
        End Sub
    
        Private Sub ClearGroupbox(ByVal T As GroupBox)
            T.Controls.ClearControls()
        End Sub
    
        <Runtime.CompilerServices.Extension()> _
        Public Sub ClearControls(ByVal Controls As ControlCollection)
            For Each Control In Controls
                If ControlDefaults.ContainsKey(Control.GetType()) Then
                    ControlDefaults(Control.GetType()).Invoke(Control)
                End If
            Next
        End Sub
    
        Private _ControlDefaults As Dictionary(Of Type, Action(Of Control))
        Private ReadOnly Property ControlDefaults() As Dictionary(Of Type, Action(Of Control))
            Get
                If (_ControlDefaults Is Nothing) Then
                    _ControlDefaults = New Dictionary(Of Type, Action(Of Control))
                    _ControlDefaults.Add(GetType(TextBox), AddressOf ClearTextBox)
                    _ControlDefaults.Add(GetType(CheckBox), AddressOf ClearCheckBox)
                    _ControlDefaults.Add(GetType(ListBox), AddressOf ClearListBox)
                    _ControlDefaults.Add(GetType(GroupBox), AddressOf ClearGroupbox)
                End If
                Return _ControlDefaults
            End Get
        End Property
    
    End Module
