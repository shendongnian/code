    Public Class AnimalListWorkspace
        Public ReadOnly Property AnimalList As IEnumerable(Of AnimalViewModel)
            Get
                Dim animalVmList = New List(Of AnimalViewModel)
                For Each an In AnimalDatabase.Animals
                    If TypeOf an Is Male Then
                        animalVmList.Add(New MaleViewModel(CType(an, Male)))
                    ElseIf TypeOf an Is Female Then
                        animalVmList.Add(New FemaleViewModel(CType(an, Female)))
                    Else
                        Throw New InvalidCastException("Unknown sex/type of animal")
                    End If
                Next
                Return animalVmList
            End Get
        End Property
    End Class
