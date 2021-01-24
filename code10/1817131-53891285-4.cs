    Public Class CategoryService
        Private list As List(Of Category) = New List(Of Category) From {
            New Category() With {.Id = 1, .Name = "Category 1"},
            New Category() With {.Id = 2, .Name = "Category 2"},
            New Category() With {.Id = 3, .Name = "Category 3"}
        }
        Public Function GetAll() As IEnumerable(Of Category)
            Return list
        End Function
    End Class
