    Imports System
    Imports EnvDTE
    Imports EnvDTE80
    Imports EnvDTE90
    Imports EnvDTE90a
    Imports EnvDTE100
    Imports System.Diagnostics
    Imports System.Collections.Generic
    
    Public Module Temp
    
        Sub AddConstructorFromFields()
            DTE.UndoContext.Open("Add constructor from fields")
    
            Dim classElement As CodeClass, index As Integer
            GetClassAndInsertionIndex(classElement, index)
    
            Dim constructor As CodeFunction
            constructor = classElement.AddFunction(classElement.Name, vsCMFunction.vsCMFunctionConstructor, vsCMTypeRef.vsCMTypeRefVoid, index, vsCMAccess.vsCMAccessPublic)
    
            Dim visitedNames As New Dictionary(Of String, String)
            Dim element As CodeElement, parameterPosition As Integer, isFirst As Boolean = True
            For Each element In classElement.Children
                Dim fieldType As String
                Dim fieldName As String
                Dim parameterName As String
    
                Select Case element.Kind
                    Case vsCMElement.vsCMElementVariable
                        Dim field As CodeVariable = CType(element, CodeVariable)
                        fieldType = field.Type.AsString
                        fieldName = field.Name
                        parameterName = field.Name.TrimStart("_".ToCharArray())
    
                    Case vsCMElement.vsCMElementProperty
                        Dim field As CodeProperty = CType(element, CodeProperty)
                        If field.Setter.Access = vsCMAccess.vsCMAccessPrivate Then
                            fieldType = field.Type.AsString
                            fieldName = field.Name
                            parameterName = field.Name.Substring(0, 1).ToLower() + field.Name.Substring(1)
                        End If
                End Select
    
                If Not String.IsNullOrEmpty(parameterName) And Not visitedNames.ContainsKey(parameterName) Then
                    visitedNames.Add(parameterName, parameterName)
    
                    constructor.AddParameter(parameterName, fieldType, parameterPosition)
    
                    Dim endPoint As EditPoint
                    endPoint = constructor.EndPoint.CreateEditPoint()
                    endPoint.LineUp()
                    endPoint.EndOfLine()
    
                    If Not isFirst Then
                        endPoint.Insert(Environment.NewLine)
                    Else
                        isFirst = False
                    End If
    
                    endPoint.Insert(String.Format(MemberAssignmentFormat(constructor.Language), fieldName, parameterName))
    
                    parameterPosition = parameterPosition + 1
                End If
            Next
    
            DTE.UndoContext.Close()
    
            Try
                ' This command fails sometimes '
                DTE.ExecuteCommand("Edit.FormatDocument")
            Catch ex As Exception
            End Try
        End Sub
        Private Sub GetClassAndInsertionIndex(ByRef classElement As CodeClass, ByRef index As Integer, Optional ByVal useStartIndex As Boolean = False)
            Dim selection As TextSelection
            selection = CType(DTE.ActiveDocument.Selection, TextSelection)
    
            classElement = CType(selection.ActivePoint.CodeElement(vsCMElement.vsCMElementClass), CodeClass)
    
            Dim childElement As CodeElement
            index = 0
            For Each childElement In classElement.Children
                Dim childOffset As Integer
                childOffset = childElement.GetStartPoint(vsCMPart.vsCMPartWholeWithAttributes).AbsoluteCharOffset
                If selection.ActivePoint.AbsoluteCharOffset < childOffset Or useStartIndex Then
                    Exit For
                End If
                index = index + 1
            Next
        End Sub
        Private ReadOnly Property MemberAssignmentFormat(ByVal language As String) As String
            Get
                Select Case language
                    Case CodeModelLanguageConstants.vsCMLanguageCSharp
                        Return "this.{0} = {1};"
    
                    Case CodeModelLanguageConstants.vsCMLanguageVB
                        Return "Me.{0} = {1}"
    
                    Case Else
                        Return ""
                End Select
            End Get
        End Property
    End Module
