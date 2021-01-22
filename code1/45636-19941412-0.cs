    #Const System_ComponentModel = True
    #Const System_Drawing = True
    Option Compare Binary
    Option Explicit On
    Option Strict On
    Imports System.Collections
    Imports System.Runtime.CompilerServices ' for Extension() attribute
    Imports System.Text
    #If System_ComponentModel Then
    Imports System.ComponentModel
    #End If
    #If System_Drawing Then
    Imports System.Drawing
    #End If
    Public Module MyExtensions
        ' other #Region blocks are removed. i use many in my Extensions module/class.
        ' the below code is only the 2 relevant extension for this 'SafeInvoke' functionality.
        ' but i use other regions such as "String extensions" and "Numeric extensions". i use the above
        ' System_ComponentModel and System_Drawing compiler directives to include or exclude blocks of code
        ' that i want to either include or exclude in a project, which allows me to easily compare my code
        ' in one project with the same file in other projects to syncronise new changes across projects.
        ' you can scrap pretty much all the code above, but i'm giving it here so you see it in the full context.
        #Region "ISynchronizeInvoke extensions"
        #If System_ComponentModel Then
            <Extension()>
            Public Function SafeInvoke(Of T As ISynchronizeInvoke, TResult)(isi As T, callFunction As Func(Of T, TResult)) As TResult
                If (isi.InvokeRequired) Then
                    Dim result As IAsyncResult = isi.BeginInvoke(callFunction, New Object() {isi})
                    Dim endresult As Object = isi.EndInvoke(result)
                    Return DirectCast(endresult, TResult)
                Else
                    Return callFunction(isi)
                End If
            End Function
            ''' <summary>
            ''' This can be used in VB with:
            ''' txtMyTextBox.SafeInvoke(Sub(d) d.Text = "This is the new Text value.")
            ''' or:
            ''' txtMyTextBox.SafeInvoke(Sub(d) d.Text = myTextStringVariable)
            ''' </summary>
            ''' <typeparam name="T"></typeparam>
            ''' <param name="isi"></param>
            ''' <param name="callFunction"></param>
            ''' <remarks></remarks>
            <Extension()>
            Public Sub SafeInvoke(Of T As ISynchronizeInvoke)(isi As T, callFunction As Action(Of T))
                If isi.InvokeRequired Then
                    isi.BeginInvoke(callFunction, New Object() {isi})
                Else
                    callFunction(isi)
                End If
            End Sub
        #End If
        #End Region
        ' other #Region blocks are removed from here too.
    End Module
