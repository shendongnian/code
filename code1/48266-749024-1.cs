     Public Class ArticleEntity
        Implements IComparable(Of ArticleEntity)
        Public Overloads Function CompareTo(ByVal Other As ArticleEntity) As Integer _
            Implements IComparable(Of ArticleEntity).CompareTo
            Return Me._PropertyToSort.CompareTo(Other._PropertyToSort)
        End Function
