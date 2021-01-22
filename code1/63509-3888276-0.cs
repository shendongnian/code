    Imports System.Runtime.CompilerServices
    
    Friend Module XElementExtensions
    
        <Extension()> _
        Public Function RemoveAllNamespaces(ByVal element As XElement) As XElement
            If element.HasElements Then
                Dim cleanElement = RemoveAllNamespaces(New XElement(element.Name.LocalName, element.Attributes))
                cleanElement.Add(element.Elements.Select(Function(el) RemoveAllNamespaces(el)))
                Return cleanElement
            Else
                Dim allAttributesExceptNamespaces = element.Attributes.Where(Function(attr) Not attr.IsNamespaceDeclaration)
                element.ReplaceAttributes(allAttributesExceptNamespaces)
                Return element
            End If
    
        End Function
    
    End Module
