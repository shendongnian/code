    Public Class Program
        Public Shared Sub Main()
            Dim myKeyBoardStyle = "dvorak"
    
            Dim myXML As XElement = <ROOT>
                                    qwerty
                                    <altKeyboard><%= myKeyBoardStyle.ToUpper() %></altKeyboard>
                                        <SampleElement>adsf</SampleElement>
                                        <SampleElement2>The text of the sample element2</SampleElement2>
                                    </ROOT>
    
            Console.WriteLine(myXML.ToString())
    
            myXML.Save(".\fileFromXElement.xml")
        End Sub
    End Class
