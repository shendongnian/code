    Module dbi
        <System.Runtime.CompilerServices.Extension()> _
        Public Function FindOrCreate( _
            Of T As {Class, New})(ByVal table As Data.Linq.Table(Of T), _
            ByVal find As Func(Of T, Boolean), _
            ByVal create As Action(Of T)) _
            As T
            Dim val As T = table.FirstOrDefault(find)
            If val Is Nothing Then
                val = New T()
                create(val)
                table.InsertOnSubmit(val)
            End If
            Return val
        End Function
        <System.Runtime.CompilerServices.Extension()> _
        Public Function FindOrCreate( _
            Of T As {Class, New})(ByVal table As Data.Linq.Table(Of T), _
            ByVal find As Func(Of T, Boolean)) _
            As T
            Return FindOrCreate(table, find, Function(a))
        End Function
    End Module
