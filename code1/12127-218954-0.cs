    Public Class ExecutionContext
        ''' <summary>
        ''' Gets a value indicating whether the application is a windows service.
        ''' </summary>
        ''' <value>
        ''' <c>true</c> if this instance is service; otherwise, <c>false</c>.
        ''' </value>
        Public Shared ReadOnly Property IsService() As Boolean
            Get
                ' Determining whether or not the host application is a service is
                ' an expensive operation (it uses reflection), so we cache the
                ' result of the first call to this method so that we don't have to
                ' recalculate it every call.
    
                ' If we have not already determined whether or not the application
                ' is running as a service...
                If IsNothing(_isService) Then
    
                    ' Get details of the host assembly.
                    Dim entryAssembly As Reflection.Assembly = Reflection.Assembly.GetEntryAssembly
    
                    ' Get the method that was called to enter the host assembly.
                    Dim entryPoint As System.Reflection.MethodInfo = entryAssembly.EntryPoint
    
                    ' If the base type of the host assembly inherits from the
                    ' "ServiceBase" class, it must be a windows service. We store
                    ' the result ready for the next caller of this method.
                    _isService = (entryPoint.ReflectedType.BaseType.FullName = "System.ServiceProcess.ServiceBase")
    
                End If
    
                ' Return the cached result.
                Return CBool(_isService)
            End Get
        End Property
    
        Private Shared _isService As Nullable(Of Boolean) = Nothing
    #End Region
    End Class
