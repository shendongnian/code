     ''' <summary>
        ''' Gets the full XPath of a single node.
        ''' </summary>
        ''' <param name="node"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetXPath(ByVal node As Xml.XmlNode) As String
            Dim temp As String
            Dim sibling As Xml.XmlNode
            Dim previousSiblings As Integer = 0
            'Prime it
            sibling = node.PreviousSibling
            'Perculate up getting the count of all of this node's sibling before it.
            While sibling IsNot Nothing
                'Only count if the sibling has the same name as this node
                If sibling.Name = node.Name Then
                    previousSiblings += 1
                End If
                sibling = sibling.PreviousSibling
            End While
            'Mark this node's index
            temp = node.Name + "[" + previousSiblings.ToString() + "]"
            If node.ParentNode IsNot Nothing Then
                Return GetXPath(node.ParentNode) + "\" + temp
            End If
            Return temp
        End Function
