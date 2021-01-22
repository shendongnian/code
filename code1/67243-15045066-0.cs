	'Declares a delegate sub that takes no parameters
	Delegate Sub ComboDelegate()
	'Loads form and controls
	Private Sub LoadForm(sender As System.Object, e As System.EventArgs) _
		Handles MyBase.Load
		ComboBox1.Items.Add("This is okay")
		ComboBox1.Items.Add("This is NOT okay")
		ResetComboBox()
	End Sub
	'Handles Selected Index Changed Event for combo Box
	Private Sub ComboBoxSelectionChanged(sender As System.Object, e As System.EventArgs) _
		Handles ComboBox1.SelectedIndexChanged
		'if option 2 selected, reset control back to original
		If ComboBox1.SelectedIndex = 1 Then
			BeginInvoke(New ComboDelegate(AddressOf ResetComboBox))
		End If
	End Sub
	'Exits out of ComboBox selection and displays prompt text 
	Private Sub ResetComboBox()
		With ComboBox1
			.SelectedIndex = -1
			.Text = "Select an option"
			.Focus()
		End With
	End Sub
