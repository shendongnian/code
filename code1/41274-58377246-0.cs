    Public Sub TestBatch_SomeContext()
        Dim TestedDictionary As IDictionary(Of Integer, String) = New ObjectDictionary()
        Dim ControlDictionary As IDictionary(Of Integer, String) = New Dictionary(Of Integer, String)
        Dim MyTestingSet As New TestingRoutines.Collections.Testing_IDictionary(Of Integer, String)(ControlDictionary, TestedDictionary)
        Dim SomeKeys() As Integer = {8, 3, 4, 1, 12, 45, 98, 65}
        Dim SomeValues() As String = {"mopet", "789", "%*+", "15/12/1995", "", "Europe", "abcd", "okay"}
        Dim OtherKeys() As Integer = {11, 22, 33, 44, 55, 101}
        Dim OtherValues() As String = {"a value?", "words in here", "06/01/2010", "something", "Europe", "voila"}
        MyTestingSet.TestFullBatch(SomeKeys, SomeValues, OtherKeys, OtherValues)
    End Sub
