	Imports System
	Imports EnvDTE
	Imports EnvDTE80
	Imports EnvDTE90
	Imports EnvDTE100
	Imports System.Diagnostics
	Imports System.Collections.Generic
	Public Module ConstructorEditor
		Public Sub AddConstructorFromFields()
			Dim classInfo As CodeClass2 = GetClassElement()
			If classInfo Is Nothing Then
				System.Windows.Forms.MessageBox.Show("No class was found surrounding the cursor.  Make sure that this file compiles and try again.", "Error")
				Return
			End If
			' Setting up undo context. One Ctrl+Z undoes everything
			Dim closeUndoContext As Boolean = False
			If DTE.UndoContext.IsOpen = False Then
				closeUndoContext = True
				DTE.UndoContext.Open("AddConstructorFromFields", False)
			End If
			Try
				Dim dataMembers As List(Of DataMember) = GetDataMembers(classInfo)
				AddConstructor(classInfo, dataMembers)
			Finally
				If closeUndoContext Then
					DTE.UndoContext.Close()
				End If
			End Try
		End Sub
		Private Function GetClassElement() As CodeClass2
			' Returns a CodeClass2 element representing the class that the cursor is within, or null if there is no class
			Try
				Dim selection As TextSelection = DTE.ActiveDocument.Selection
				Dim fileCodeModel As FileCodeModel2 = DTE.ActiveDocument.ProjectItem.FileCodeModel
				Dim element As CodeElement2 = fileCodeModel.CodeElementFromPoint(selection.TopPoint, vsCMElement.vsCMElementClass)
				Return element
			Catch
				Return Nothing
			End Try
		End Function
		Private Function GetDataMembers(ByVal classInfo As CodeClass2) As System.Collections.Generic.List(Of DataMember)
			Dim dataMembers As List(Of DataMember) = New List(Of DataMember)
			Dim prop As CodeProperty2
			Dim v As CodeVariable2
			For Each member As CodeElement2 In classInfo.Members
				prop = TryCast(member, CodeProperty2)
				If Not prop Is Nothing Then
					dataMembers.Add(DataMember.FromProperty(prop.Name, prop.Type))
				End If
				v = TryCast(member, CodeVariable2)
				If Not v Is Nothing Then
					If v.Name.StartsWith("_") And Not v.IsConstant Then
						dataMembers.Add(DataMember.FromPrivateVariable(v.Name, v.Type))
					End If
				End If
			Next
			Return dataMembers
		End Function
		Private Sub AddConstructor(ByVal classInfo As CodeClass2, ByVal dataMembers As List(Of DataMember))
			' Put constructor after the data members
			Dim position As Object = dataMembers.Count
			' Add new constructor
			Dim ctor As CodeFunction2 = classInfo.AddFunction(classInfo.Name, vsCMFunction.vsCMFunctionConstructor, vsCMTypeRef.vsCMTypeRefVoid, position, vsCMAccess.vsCMAccessPublic)
			For Each dataMember As DataMember In dataMembers
				ctor.AddParameter(dataMember.NameLocal, dataMember.Type, -1)
			Next
			' Assignments
			Dim startPoint As TextPoint = ctor.GetStartPoint(vsCMPart.vsCMPartBody)
			Dim point As EditPoint = startPoint.CreateEditPoint()
			For Each dataMember As DataMember In dataMembers
				point.Insert("            " + dataMember.Name + " = " + dataMember.NameLocal + ";" + Environment.NewLine)
			Next
		End Sub
		Class DataMember
			Public Name As String
			Public NameLocal As String
			Public Type As Object
			Private Sub New(ByVal name As String, ByVal nameLocal As String, ByVal type As Object)
				Me.Name = name
				Me.NameLocal = nameLocal
				Me.Type = type
			End Sub
			Shared Function FromProperty(ByVal name As String, ByVal type As Object)
				Dim nameLocal As String
				If Len(name) > 1 Then
					nameLocal = name.Substring(0, 1).ToLower + name.Substring(1)
				Else
					nameLocal = name.ToLower()
				End If
				Return New DataMember(name, nameLocal, type)
			End Function
			Shared Function FromPrivateVariable(ByVal name As String, ByVal type As Object)
				If Not name.StartsWith("_") Then
					Throw New ArgumentException("Expected private variable name to start with underscore.")
				End If
				Dim nameLocal As String = name.Substring(1)
				Return New DataMember(name, nameLocal, type)
			End Function
		End Class
	End Module
