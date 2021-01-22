    Private Shared Sub InitStructureMap()
    ObjectFactory.Initialize(Function (ByVal x As IInitializationExpression) 
        x.AddRegistry(New DataAccessRegistry)
        x.AddRegistry(New CoreRegistry)
        x.AddRegistry(New WebUIRegistry)
        x.Scan(Function (ByVal scanner As IAssemblyScanner) 
            scanner.Assembly("RPMWare.Core")
            scanner.Assembly("RPMWare.Core.DataAccess")
            scanner.WithDefaultConventions
        End Function)
    End Function)
    End Sub
