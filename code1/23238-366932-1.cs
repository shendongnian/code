    Private Shared Sub Foobar(x As IInitializationExpression)
        x.AddRegistry(New DataAccessRegistry)
        x.AddRegistry(New CoreRegistry)
        x.AddRegistry(New WebUIRegistry)
        x.Scan(AddressOf Barfoo)
    End Sub
    Private Static Sub Barfoo(ByVal scanner As IAssemblyScanner) 
        scanner.Assembly("RPMWare.Core")
        scanner.Assembly("RPMWare.Core.DataAccess")
        scanner.WithDefaultConventions
    End Sub
    ' … '
    ObjectFactory.Initialize(AddressOf Foobar)
