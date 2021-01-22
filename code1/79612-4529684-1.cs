    Public Function FindSubClasses(Of TBaseType)() As IEnumerable(Of Type)
		
        Dim baseType = GetType(TBaseType)
        Dim assembly = baseType.Assembly
		
        Return From t In assembly.GetTypes() 
               Where t.IsSubClassOf(baseType) 
               Select t
		
    End Function
