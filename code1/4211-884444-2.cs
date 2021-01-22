    Public Shared ReadOnly Property AssemblyDirectory() As String
        Get
	        Dim codeBase As String = Assembly.GetExecutingAssembly().CodeBase
	        Dim uriBuilder As New UriBuilder(codeBase)
	        Dim assemblyPath As String = Uri.UnescapeDataString(uriBuilder.Path)
	        Return Path.GetDirectoryName(assemblyPath)
	    End Get
    End Property
