    Option Strict On
    Option Explicit On
    Option Infer Off
    
    Imports System.Runtime.CompilerServices
    Imports System.Reflection
    Imports System.ComponentModel
    
    Module EnumExtensions
      Private _Descriptions As New Dictionary(Of String, String)
    
      ''' <summary>
      ''' This extension method adds a Description method
      ''' to all enum members. The result of the method is the
      ''' value of the Description attribute if present, else
      ''' the normal ToString() representation of the enum value.
      ''' </summary>
      <Extension>
      Public Function Description(e As [Enum]) As String
        ' Get the type of the enum
        Dim enumType As Type = e.GetType()
        ' Get the name of the enum value
        Dim name As String = e.ToString()
    
        ' Construct a full name for this enum value
        Dim fullName As String = enumType.FullName + "." + name
    
        ' See if we have looked it up earlier
        Dim enumDescription As String = Nothing
        If _Descriptions.TryGetValue(fullName, enumDescription) Then
          ' Yes we have - return previous value
          Return enumDescription
        End If
    
        ' Find the value of the Description attribute on this enum value
        Dim members As MemberInfo() = enumType.GetMember(name)
        If members IsNot Nothing AndAlso members.Length > 0 Then
          Dim descriptions() As Object = members(0).GetCustomAttributes(GetType(DescriptionAttribute), False)
          If descriptions IsNot Nothing AndAlso descriptions.Length > 0 Then
            ' Set name to description found
            name = DirectCast(descriptions(0), DescriptionAttribute).Description
          End If
        End If
    
        ' Save the name in the dictionary:
        _Descriptions.Add(fullName, name)
    
        ' Return the name
        Return name
      End Function
    End Module
