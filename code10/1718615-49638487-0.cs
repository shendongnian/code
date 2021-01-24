      Public Shared Function FindParent(Of T As DependencyObject)(ByVal child As DependencyObject) As T
        Dim parentObject As DependencyObject = VisualTreeHelper.GetParent(child)
        If parentObject Is Nothing Then Return Nothing
        Dim parent As T = TryCast(parentObject, T)
        If parent IsNot Nothing Then Return parent Else Return FindParent(Of T)(parentObject)
    End Function
