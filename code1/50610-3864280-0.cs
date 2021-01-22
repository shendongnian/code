    Module dbi
        <System.Runtime.CompilerServices.Extension()> _
        Public Function FindOrCreate(Of T As {Class, New})(ByVal table As Data.Linq.Table(Of T), ByVal find As Func(Of T, Boolean), ByVal create As Action(Of T)) As T
            Dim val As T = table.FirstOrDefault(find)
            If val Is Nothing Then
                val = New T()
                create(val)
                table.InsertOnSubmit(val)
            End If
            Return val
        End Function
        <System.Runtime.CompilerServices.Extension()> _
        Public Function FindOrCreate(Of T As {Class, New})(ByVal table As Data.Linq.Table(Of T), ByVal find As Func(Of T, Boolean)) As T
            Return FindOrCreate(table, find, Function(a)
    
                                             End Function)
        End Function
    
    End Module
