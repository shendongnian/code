    Public Function FindDescendant(ByVal MyElementToSeek As FrameworkElement, _
                                      ByVal TypeToFind As Type) As FrameworkElement
        If MyElementToSeek Is Nothing Then Return Nothing
        If MyElementToSeek.GetType() = TypeToFind Then Return MyElementToSeek
        For i = 0 To VisualTreeHelper.GetChildrenCount(MyElementToSeek) - 1
            Dim OneChild = TryCast(VisualTreeHelper.GetChild(MyElementToSeek, i), FrameworkElement)
            Dim Result = FindDescendant(OneChild, TypeToFind)
            If Result IsNot Nothing Then Return Result
        Next
        Return Nothing
    End Function
.
    public FrameworkElement FindDescendant(FrameworkElement MyElementToSeek, 
                                             Type TypeToFind) 
    {
        if (MyElementToSeek == null) return null;
        if (MyElementToSeek.GetType() == TypeToFind) return MyElementToSeek;
        for (i = 0; 
                   (i<= (VisualTreeHelper.GetChildrenCount(MyElementToSeek) - 1)); i++) 
          {
            object OneChild = TryCast(VisualTreeHelper.GetChild(MyElementToSeek, i),
                                                             FrameworkElement);
            object Result = FindDescendant(OneChild, TypeToFind);
            if (Result) return Result;
            }
         return null;
        }
    }
        ' MyScrollViewer = FindDescendant(MyListView, ScrollViewer)
