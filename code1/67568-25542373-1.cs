     Private Sub loadSettings()
        If Not IsNothing(My.Settings.YourDGVSettingsEntry) Then
            Dim s As MySettingTypes.DataGridViewColumnSetting = My.Settings.YourDGVSettingsEntry
            Dim pos As Integer = 0
            For Each ColumnName As String In s.ColumnNames
                Try
                    Me.YourDataGridView.Columns(ColumnName).DisplayIndex = s.ColumnDisplayIndex(pos)
                    Me.YourDataGridView.Columns(ColumnName).Width = s.ColumnSize(pos)
                    Me.YourDataGridView.Columns(ColumnName).Visible = s.ColumnVisiblility(pos)
                Catch ex As Exception
                End Try
                pos = pos + 1
            Next
        Else
            My.Settings.YourDGVSettingsEntry = New MySettingTypes.DataGridViewColumnSetting
            Me.saveSettings()
        End If
    End Sub
    Private Sub saveSettings()
        Dim x As New MySettingTypes.DataGridViewColumnSetting
        For Each c As DataGridViewColumn In YourDataGridView.Columns
            x.ColumnNames.Add(c.Name)
            x.ColumnDisplayIndex.Add(c.DisplayIndex)
            x.ColumnSize.Add(c.Width)
            x.ColumnVisiblility.Add(c.Visible)
            My.Settings.YourDGVsettingsEntry = x
            My.Settings.Save()
        Next
    End Sub
    Private Sub yourDGVForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'txtResultsCount.Text = "Saving settings"
        saveSettings()
    End Sub
    Private Sub yourDGVForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' myparent = Me.MdiParent
        loadSettings()
        'Setup()
    End Sub
 
