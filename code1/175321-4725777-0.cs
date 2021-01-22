    <w:bookmarkStart w:name="forbund_kort" w:id="0" /> 
            - <w:r>
              <w:t>forbund_kort</w:t> 
              </w:r>
    <w:bookmarkEnd w:id="0" />
    Imports DocumentFormat.OpenXml.Packaging
    Imports DocumentFormat.OpenXml.Wordprocessing
        
        Public Class PPWordDocx
        
            Public Sub ChangeBookmarks(ByVal path As String)
                Try
                    Dim doc As WordprocessingDocument = WordprocessingDocument.Open(path, True)
                     'Read the entire document contents using the GetStream method:
        
                    Dim bookmarkMap As IDictionary(Of String, BookmarkStart) = New Dictionary(Of String, BookmarkStart)()
                    Dim bs As BookmarkStart
                    For Each bs In doc.MainDocumentPart.RootElement.Descendants(Of BookmarkStart)()
                        bookmarkMap(bs.Name) = bs
                    Next
                    For Each bs In bookmarkMap.Values
                        Dim bsText As DocumentFormat.OpenXml.OpenXmlElement = bs.NextSibling
                        If Not bsText Is Nothing Then
                            If TypeOf bsText Is BookmarkEnd Then
                                'Add Text element after start bookmark
                                bs.Parent.InsertAfter(New Run(New Text(bs.Name)), bs)
                            Else
                                'Change Bookmark Text
                                If TypeOf bsText Is Run Then
                                    If bsText.GetFirstChild(Of Text)() Is Nothing Then
                                        bsText.InsertAt(New Text(bs.Name), 0)
                                    End If
                                    bsText.GetFirstChild(Of Text)().Text = bs.Name
                                End If
                            End If
        
                        End If
                    Next
                    doc.MainDocumentPart.RootElement.Save()
                    doc.Close()
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub
        
        End Class
