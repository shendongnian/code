    Imports System
    Imports System.Collections.Generic
    Imports Microsoft.Build.Framework
    
    Public Class FakeBuildEngine
        Implements IBuildEngine
    
        // It's just a test helper so public fields is fine.
        Public LogErrorEvents As New List(Of BuildErrorEventArgs)
        Public LogMessageEvents As New List(Of BuildMessageEventArgs)
        Public LogCustomEvents As New List(Of CustomBuildEventArgs)
        Public LogWarningEvents As New List(Of BuildWarningEventArgs)
    
        Public Function BuildProjectFile(
            projectFileName As String, 
            targetNames() As String, 
            globalProperties As System.Collections.IDictionary, 
            targetOutputs As System.Collections.IDictionary) As Boolean
            Implements IBuildEngine.BuildProjectFile
            Throw New NotImplementedException
        End Function
    
        Public ReadOnly Property ColumnNumberOfTaskNode As Integer 
            Implements IBuildEngine.ColumnNumberOfTaskNode
            Get
                Return 0
            End Get
        End Property
    
        Public ReadOnly Property ContinueOnError As Boolean
            Implements IBuildEngine.ContinueOnError
            Get
                Throw New NotImplementedException
            End Get
        End Property
    
        Public ReadOnly Property LineNumberOfTaskNode As Integer
            Implements IBuildEngine.LineNumberOfTaskNode
            Get
                Return 0
            End Get
        End Property
    
        Public Sub LogCustomEvent(e As CustomBuildEventArgs)
            Implements IBuildEngine.LogCustomEvent
            LogCustomEvents.Add(e)
        End Sub
    
        Public Sub LogErrorEvent(e As BuildErrorEventArgs)
            Implements IBuildEngine.LogErrorEvent
            LogErrorEvents.Add(e)
        End Sub
    
        Public Sub LogMessageEvent(e As BuildMessageEventArgs)
            Implements IBuildEngine.LogMessageEvent
            LogMessageEvents.Add(e)
        End Sub
    
        Public Sub LogWarningEvent(e As BuildWarningEventArgs)
            Implements IBuildEngine.LogWarningEvent
            LogWarningEvents.Add(e)
        End Sub
    
        Public ReadOnly Property ProjectFileOfTaskNode As String
            Implements IBuildEngine.ProjectFileOfTaskNode
            Get
                Return "fake ProjectFileOfTaskNode"
            End Get
        End Property
    
    End Class
