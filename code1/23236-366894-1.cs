     Private Shared Sub InitStructureMap()
    ObjectFactory.Initialize(Function (ByVal x As IInitializationExpression) _
        x.AddRegistry(New DataAccessRegistry) _
        x.AddRegistry(New CoreRegistry) _
        x.AddRegistry(New WebUIRegistry) _
        x.Scan(Function (ByVal scanner As IAssemblyScanner) _
        scanner.Assembly("RPMWare.Core") _
        scanner.Assembly("RPMWare.Core.DataAccess") _
        scanner.WithDefaultConventions() _
        End Function) _
    End Function) 
    End Sub
