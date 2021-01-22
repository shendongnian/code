     Public Class ArticleEntity
        Implements IComparable(Of ArticleEntity)
        Public Overloads Function CompareTo(ByVal Other As Category) As Integer _
            Implements IComparable(Of Category).CompareTo
            Return Me._PropertyToSort.CompareTo(Other._PropertyToSort)
        End Function
