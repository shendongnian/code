    'OrgDetailsIDComboBox
    '
    Me.OrgDetailsIDComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MedicoLegalBindingSource, "OrgDetailsID", True))
    Me.OrgDetailsIDComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.MedicoLegalBindingSource, "OrgDetailsID", True))
    Me.OrgDetailsIDComboBox.DataSource = Me.OrgBindingSource
    Me.OrgDetailsIDComboBox.DisplayMember = "Place"
