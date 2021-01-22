Imports System
Imports EnvDTE
Imports EnvDTE80
Imports EnvDTE90
Imports EnvDTE100
Imports System.Diagnostics
Public Module ConstructorEditor
    Public Sub StubConstructors()
        'adds stubs for all of the constructors in the current class's base class
        Dim selection As TextSelection = DTE.ActiveDocument.Selection
        Dim classInfo As CodeClass2 = GetClassElement()
        If classInfo Is Nothing Then
            System.Windows.Forms.MessageBox.Show("No class was found surrounding the cursor.  Make sure that this file compiles and try again.", "Error")
            Return
        End If
        If classInfo.Bases.Count = 0 Then
            System.Windows.Forms.MessageBox.Show("No parent class was found for this class.  Make sure that this file, and any file containing parent classes compiles and try again")
            Return
        End If
        'setting up an undo context -- one ctrl+z undoes everything
        Dim closeUndoContext As Boolean = False
        If DTE.UndoContext.IsOpen = False Then
            closeUndoContext = True
            DTE.UndoContext.Open("StubConstructorsContext", False)
        End If
        Try
            Dim parentInfo As CodeClass2 = classInfo.Bases.Item(1)
            Dim childConstructors As System.Collections.Generic.List(Of CodeFunction2) = GetConstructors(classInfo)
            Dim parentConstructors As System.Collections.Generic.List(Of CodeFunction2) = GetConstructors(parentInfo)
            For Each constructor As CodeFunction2 In parentConstructors
                If Not MatchingSignatureExists(constructor, childConstructors) Then
                    ' we only want to create ctor stubs for ctors that are missing
                    ' note: a dictionary could be more efficient, but I doubt most classes will have more than 4 or 5 ctors...
                    StubConstructor(classInfo, constructor)
                End If
            Next
        Finally
            If closeUndoContext Then
                DTE.UndoContext.Close()
            End If
        End Try
    End Sub
    Private Function GetConstructors(ByVal classInfo As CodeClass2) As System.Collections.Generic.List(Of CodeFunction2)
        ' return a list of all of the constructors in the specified class
        Dim result As System.Collections.Generic.List(Of CodeFunction2) = New System.Collections.Generic.List(Of CodeFunction2)
        Dim func As CodeFunction2
        For Each member As CodeElement2 In classInfo.Members
            ' members collection has all class members.  filter out just the function members, and then of the functions, grab just the ctors
            func = TryCast(member, CodeFunction2)
            If func Is Nothing Then Continue For
            If func.FunctionKind = vsCMFunction.vsCMFunctionConstructor Then
                result.Add(func)
            End If
        Next
        Return result
    End Function
    Private Function MatchingSignatureExists(ByVal searchFunction As CodeFunction2, ByVal functions As System.Collections.Generic.List(Of CodeFunction2)) As Boolean
        ' given a function (searchFunction), searches a list of functions where the function signatures (not necessarily the names) match
        ' return null if no match is found, otherwise returns first match
        For Each func As CodeFunction In functions
            If func.Parameters.Count <> searchFunction.Parameters.Count Then Continue For
            Dim searchParam As CodeParameter2
            Dim funcParam As CodeParameter2
            Dim match As Boolean = True
            For count As Integer = 1 To searchFunction.Parameters.Count
                searchParam = searchFunction.Parameters.Item(count)
                funcParam = func.Parameters.Item(count)
                If searchParam.Type.AsFullName <> funcParam.Type.AsFullName Then
                    match = False
                    Exit For
                End If
            Next
            If match Then
                Return True
            End If
        Next
        ' no match found
        Return False
    End Function
    Private Sub StubConstructor(ByVal classInfo As CodeClass2, ByVal parentConstructor As CodeFunction2)
        ' adds a constructor to the current class, based upon the parentConstructor that is passed in
        ' highly inefficient hack to position the ctor where I want it (after the last ctor in the class, if there is another ctor
        ' note that passing zero as the position (put the ctor first) caused some problems when we were adding ctors to classes that already had ctors
        Dim position As Object
        Dim ctors As System.Collections.Generic.List(Of CodeFunction2) = GetConstructors(classInfo)
        If ctors.Count = 0 Then
            position = 0
        Else
            position = ctors.Item(ctors.Count - 1)
        End If
        ' if there are no other ctors, put this one at the top
        Dim ctor As CodeFunction2 = classInfo.AddFunction(classInfo.Name, vsCMFunction.vsCMFunctionConstructor, vsCMTypeRef.vsCMTypeRefVoid, position, parentConstructor.Access)
        Dim baseCall As String = ":base("
        Dim separator As String = ""
        For Each parameter As CodeParameter2 In parentConstructor.Parameters
            ctor.AddParameter(parameter.Name, parameter.Type, -1)
            baseCall += separator + parameter.Name
            separator = ", "
        Next
        baseCall += ")"
        ' and 1 sad hack -- appears to be no way to programmatically add the :base() calls without using direct string manipulation
        Dim startPoint As TextPoint = ctor.GetStartPoint()
        Dim endOfSignature As EditPoint = startPoint.CreateEditPoint()
        endOfSignature.EndOfLine()
        endOfSignature.Insert(baseCall)
        startPoint.CreateEditPoint().SmartFormat(endOfSignature)
    End Sub
    Private Function GetClassElement() As CodeClass2
        'returns a CodeClass2 element representing the class that the cursor is within, or null if there is no class
        Try
            Dim selection As TextSelection = DTE.ActiveDocument.Selection
            Dim fileCodeModel As FileCodeModel2 = DTE.ActiveDocument.ProjectItem.FileCodeModel
            Dim element As CodeElement2 = fileCodeModel.CodeElementFromPoint(selection.TopPoint, vsCMElement.vsCMElementClass)
            Return element
        Catch
            Return Nothing
        End Try
    End Function
End Module
