    Partial Class UserControlStrings_TabMenu
        Inherits System.Web.UI.UserControl
    
        Private _Tabs As New MyTabsClass(Me)
    
        <PersistenceMode(PersistenceMode.InnerProperty)>
        Public ReadOnly Property Tabs As MyTabsClass
            Get
                Return _Tabs
            End Get
        End Property
    End Class
    
    Public Class MyTabsClass
        Inherits ControlCollection
    
        Sub New(ByVal owner As Control)
            MyBase.New(owner)
        End Sub
    
        Public Overrides Sub Add(ByVal child As System.Web.UI.Control)
            MyBase.Add(New MyTab(child))
        End Sub
    End Class
    
    
    Public Class MyTab
        Inherits HtmlGenericControl
    
        Sub New(ByVal GenericControl As HtmlGenericControl)
            MyBase.New()
            Me.Label = GenericControl.Attributes("Label")
            Me.PanelId = GenericControl.Attributes("Panelid")
        End Sub
    
        Public Property Label As String = String.Empty
        Public Property PanelId As String = String.Empty
    
        Public Overrides Function ToString() As String
            Return Me.Label & "-" & Me.PanelId
        End Function
    End Class
