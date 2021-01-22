    Public Class Installer1
    Public Sub New()
        MyBase.New()
        'This call is required by the Component Designer.
        InitializeComponent()
        'Add initialization code after the call to InitializeComponent
    End Sub
    <Security.Permissions.SecurityPermission(Security.Permissions.SecurityAction.Demand)>
    Public Overrides Sub Install(ByVal stateSaver As System.Collections.IDictionary)
        MyBase.Install(stateSaver)
        YourCustomInstallAction2BeRenamed()
    End Sub
    <Security.Permissions.SecurityPermission(Security.Permissions.SecurityAction.Demand)>
    Public Overrides Sub Commit(ByVal savedState As System.Collections.IDictionary)
        MyBase.Commit(savedState)
    End Sub
    <Security.Permissions.SecurityPermission(Security.Permissions.SecurityAction.Demand)>
    Public Overrides Sub Rollback(ByVal savedState As System.Collections.IDictionary)
        MyBase.Rollback(savedState)
        YourCustomRollbackAction2BeRenamed()
    End Sub
    <Security.Permissions.SecurityPermission(Security.Permissions.SecurityAction.Demand)>
    Public Overrides Sub Uninstall(ByVal savedState As System.Collections.IDictionary)
        MyBase.Uninstall(savedState)
        YourCustomDeleteAction2BeRenamed()
    End Sub
