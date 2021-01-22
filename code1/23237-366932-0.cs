    Private Shared Function Foobar(x As IInitializationExpression)
        x.AddRegistry(New DataAccessRegistry)
        x.AddRegistry(New CoreRegistry)
        x.AddRegistry(New WebUIRegistry)
        x.Scan(AddressOf Barfoo)
    End Function
    Private Static Function Barfoo(ByVal scanner As IAssemblyScanner) 
        scanner.Assembly("RPMWare.Core")
        scanner.Assembly("RPMWare.Core.DataAccess")
        scanner.WithDefaultConventions
    End Function
    ' … '
    ObjectFactory.Initialize(AddressOf Foobar)
