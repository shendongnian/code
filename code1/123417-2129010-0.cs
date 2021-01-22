    Public Class Form1
    
        'give a variable as a TabPage here so we know which one is selected(in focus)
        Dim selectedPage As TabPage = TabPage1
    
        'If a key is pressed when the tab control has focus, it checks to see if it is the right tab page
        'and then show a message box(for demonstration)
        Private Sub TabControl1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl1.KeyDown
            'The IF Not is to basically catch any odd happening that might occur if a key stroke gets passed with
            'no selected tab page
            If Not selectedPage Is Nothing Then
                'If the tabpage is TabPage2
                If selectedPage.Name = "TabPage2" Then
                    MessageBox.Show("Key Pressed")
                End If
            End If
        End Sub
    
        'This handles the actual chaning of the tab pages
        Private Sub TabControl1_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected
            selectedPage = TabControl1.SelectedTab
        End Sub
