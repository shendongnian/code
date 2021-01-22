     Private Sub ComboBox1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles ComboBox_AllSites.SelectionChanged
    
            Dim cr As System.Windows.Controls.ComboBoxItem = ComboBox1.SelectedValue
    
            Dim currentText = cr.Content
    
            MessageBox.Show(currentText)
    
        End Sub
