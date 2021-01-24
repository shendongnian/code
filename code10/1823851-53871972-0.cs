    Imports System.Collections.ObjectModel
    Imports System.ComponentModel
    Public Class Form1
        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
            Dim tc1 As New TestClass1
            PropertyGrid1.SelectedObject = tc1
        End Sub
        <TypeConverter(GetType(ExpandableObjectConverter))>
        Public Class TestClass1
            Public ReadOnly Property TestProperty1 As TestClass2 = New TestClass2()
        End Class
        <TypeConverter(GetType(ExpandableObjectConverter))>
        Public NotInheritable Class TestClass2
            <TypeConverter(GetType(CollectionConverter))>
            Public ReadOnly Property TestProperty2 As ReadOnlyCollection(Of TestClass3)
                Get
                    Dim collection As New List(Of TestClass3)
                    For i As Integer = 0 To 10
                        collection.Add(New TestClass3())
                    Next
                    Return collection.AsReadOnly()
                End Get
            End Property
        End Class
        <TypeConverter(GetType(ExpandableObjectConverter))>
        Public NotInheritable Class TestClass3
            <Category("Category 1")>
            Public ReadOnly Property TestProperty1 As String = "Test 1"
            <Category("Category 1")>
            Public ReadOnly Property TestProperty2 As String = "Test 2"
            <Category("Category 1")>
            Public ReadOnly Property TestProperty3 As String = "Test 3"
            <Category("Category 2")>
            Public ReadOnly Property TestProperty21 As String = "Test 21"
            <Category("Category 2")>
            Public ReadOnly Property TestProperty22 As String = "Test 22"
            <Category("Category 2")>
            Public ReadOnly Property TestProperty23 As String = "Test 23"
            'We use the following dummy property to overcome the problem with the propertygrid
            'that it doesn't display the categories once all the properties in the category
            'are readonly...
            <Browsable(False)>
            Public Property DummyWriteableProperty As String
                Get
                    Return String.Empty
                End Get
                Set(value As String)
                End Set
            End Property
        End Class
    End Class
