    Partial Public Class MenuSection
    Private _ChildMenus As Generic.List(Of MenuSection)
    Public Property ChildMenus() As Generic.List(Of MenuSection)
        Get
            If _ChildMenus Is Nothing Then
                ' Load the data in the list
                _ChildMenus = New SubSonic.Select().From(Data.MenuSelection). _
                Where("ParentMenuItemId").IsEqualTo(1). _
                ExecuteTypedList(Of Data.MenuSelection)()
            End If
            Return _ChildMenus
        End Get
        Set(ByVal value As Generic.List(Of MenuSection))
            _ChildMenus = value
        End Set
    End Property
