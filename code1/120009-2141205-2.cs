    Public Class NotifyApplicationContext
    Inherits ApplicationContext
    Private components As System.ComponentModel.IContainer
    Private Notify As System.Windows.Forms.NotifyIcon
    Private Menu As System.Windows.Forms.ContextMenu
    Private mnuForm As System.Windows.Forms.MenuItem
    Private F As Form
    Public Sub New()
        InitializeContext()
    End Sub
    Private Sub InitializeContext()
        Me.components = New System.ComponentModel.Container
        Me.Notify = New System.Windows.Forms.NotifyIcon(Me.components)
        SetupContextMenu()
        Notify.ContextMenu = Me.Menu
        Notify.Icon = New Icon("YourApplicationIcon", 16, 16)
        Notify.Text = "Your Application Text"
        Notify.Visible = True
        F = New Form
        F.Show()
    End Sub
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub
    Protected Overrides Sub ExitThreadCore()
        MyBase.ExitThreadCore()
    End Sub
    Private Sub SetupContextMenu()
        Me.Menu = New System.Windows.Forms.ContextMenu
        Me.mnuForm = New System.Windows.Forms.MenuItem
        Me.Menu.MenuItems.Add(mnuForm)
        mnuForm.Index = 7
        mnuForm.Text = "FormText"
        AddHandler mnuForm.Click, AddressOf Me.mnuTemp_Click
    End Sub
    Private Sub mnuForm_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If F IsNot Nothing Then
            If F.Visible = True Then
                F.Close()
                F.Dispose()
                F = Nothing
            End If
        Else
            F = New Form
            F.Show()
        End If
        Notify.Text = "Change Application Text Here"
    End Sub
