    Imports System.Net
    Imports System.Collections.Generic
    
    Public Class WebScraper
        Public Sub New()
            SetUserAgent(UserAgent.IE6SP1) ''//default agent
        End Sub
    
    #Region "Cookies"
        Private Cookies As New CookieContainer()
    
        Public Sub AddCookie(ByVal Name As String, ByVal data As String, Optional ByVal path As String = "", Optional ByVal domain As String = "")
            Dim ck As New Cookie(Name, data, path, domain)
            AddCookie(ck)
        End Sub
        Public Sub AddCookie(ByRef cookie As Cookie)
            Cookies.Add(cookie)
        End Sub
    
        Public Sub ResetSession()
            Cookies = New CookieContainer()
            ''//TODO: Add other session reset code here
        End Sub
    
        Public Function GetCookies(ByVal uri As System.Uri) As System.Net.CookieCollection
            Return Cookies.GetCookies(uri)
        End Function
        Public Function GetCookies(ByVal url As String) As Net.CookieCollection
            Dim url2 As Uri = Nothing
            If Uri.TryCreate(url, UriKind.Absolute, url2) Then
                Return Cookies.GetCookies(url2)
            Else
                Return Nothing
            End If
        End Function
    #End Region
    
        Public Property TimeOut() As UInteger
            Get
                Return _TimeOut
            End Get
            Set(ByVal value As UInteger)
                _TimeOut = value
            End Set
        End Property
        Private _TimeOut As UInteger = 100000 ''//100000 matches default used by httprequest if none is specified
    
        Public Property PageEncoding() As System.Text.Encoding
            Get
                Return _PageEncoding
            End Get
            Set(ByVal value As System.Text.Encoding)
                _PageEncoding = value
            End Set
        End Property
        Private _PageEncoding As System.Text.Encoding = System.Text.Encoding.UTF8
    
    #Region "UserAgents"
        ''// TODO: Update this for FF3, add GoogleBot
        ''// TODO: Move to separate class with distinct sub-types (eg: UserAgents.IE.6XP or UserAgents.FF.2XP, classes that overload .ToString())
        Public Enum UserAgent
            IE6SP1
            IE7_XP
            IE7_Vista
            FF2_XP
            FF2_Vista
            FF2_Mac
            FF2_Linux
            Safari
        End Enum
    
        Public Sub SetUserAgent(ByVal UserAgent As UserAgent)
            Select Case UserAgent
                Case WebScraper.UserAgent.FF2_Linux
                    Agent = "Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.8.1.4) Gecko/20070713 Firefox/2.0.0.5"
                Case WebScraper.UserAgent.FF2_Mac
                    Agent = "Mozilla/5.0 (Macintosh; U; Intel Mac OS X; en-US; rv:1.8.1) Gecko/20070713 Firefox/2.0.0.5"
                Case WebScraper.UserAgent.FF2_Vista
                    Agent = "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.8.1.3) Gecko/20070713 Firefox/2.0.0.5"
                Case WebScraper.UserAgent.FF2_XP
                    Agent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.3) Gecko/20070713 Firefox/2.0.0.5"
                Case WebScraper.UserAgent.IE6SP1
                    Agent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)"
                Case WebScraper.UserAgent.IE7_Vista
                    Agent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; .NET CLR 1.1.4322; .NET CLR 2.0.50727)"
                Case WebScraper.UserAgent.IE7_XP
                    Agent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)"
                Case WebScraper.UserAgent.Safari
                    Agent = "Mozilla/5.0 (Macintosh; U; Intel Mac OS X; en) AppleWebKit/522.12.1 (KHTML, like Gecko) Safari/522.12.1"
            End Select
        End Sub
    
        Public Sub SetUserAgent(ByVal UserAgent As String)
            Agent = UserAgent
        End Sub
    
        ''//defaults to IE6 SP1
        ''// TODO: Choose a better default
        Private Agent As String
    #End Region
    
    #Region "Get Page"
        Public Function GetPage(ByVal URL As Uri, Optional ByVal PostData As String = "") As String
            Dim reader As IO.StreamReader = Nothing
            Try
                reader = New System.IO.StreamReader(SendRequest(URL, PostData).GetResponseStream, PageEncoding)
                GetPage = reader.ReadToEnd()
            Catch
                GetPage = ""
            Finally
                Try
                    reader.Close()
                Catch
                End Try
            End Try
        End Function
        Public Function GetPage(ByVal URL As String, Optional ByVal PostData As String = "") As String
            Dim URL2 As Uri = Nothing
            If Uri.TryCreate(URL, UriKind.Absolute, URL2) Then
                Return GetPage(URL2, PostData)
            Else
                Return ""
            End If
        End Function
        Public Function GetPage(ByVal URL As String, ByRef PostData As Dictionary(Of String, String)) As String
            Return GetPage(URL, PrepPostData(PostData))
        End Function
        Public Function GetPage(ByVal URL As Uri, ByRef PostData As Dictionary(Of String, String)) As String
            Return GetPage(URL, PrepPostData(PostData))
        End Function
    #End Region
    
    #Region "Get Response"
        Public Function GetResponse(ByVal URL As Uri, Optional ByVal Postdata As String = "") As Object
            Dim x As HttpWebResponse = SendRequest(URL, Postdata)
            If x.ContentType.Contains("text") Then
                Dim result As String
                Dim reader As IO.StreamReader = Nothing
                Try
                    reader = New System.IO.StreamReader(x.GetResponseStream, System.Text.Encoding.UTF8) ''// TODO: figure out how to detect actual encoding
                    result = reader.ReadToEnd()
                Catch
                    result = ""
                Finally
                    Try
                        reader.Close()
                    Catch
                    End Try
                End Try
                Return result
            ElseIf x.ContentType.Contains("image") Then
                Dim result As Drawing.Image
                Try
                    result = System.Drawing.Image.FromStream(x.GetResponseStream)
                Catch
                    result = Nothing
                End Try
                Return result
            Else
                Return x.GetResponseStream
            End If
        End Function
        Public Function GetResponse(ByVal URL As Uri, ByRef PostData As Dictionary(Of String, String)) As Object
            Return GetResponse(URL, PrepPostData(PostData))
        End Function
        Public Function GetResponse(ByVal URL As String, ByRef PostData As Dictionary(Of String, String)) As Object
            Return GetResponse(URL, PrepPostData(PostData))
        End Function
        Public Function GetResponse(ByVal URL As String, Optional ByVal PostData As String = "") As Object
            Dim URL2 As Uri = Nothing
            If Uri.TryCreate(URL, UriKind.Absolute, URL2) Then
                Return GetResponse(URL2, PostData)
            Else
                Return Nothing
            End If
        End Function
    #End Region
    
    #Region "SaveResponseToFile"
        Function SaveResponseToFile(ByVal FullFileName As String, ByVal URL As Uri, Optional ByVal PostData As String = "") As Boolean
            Try
                Dim x As New IO.BinaryReader(SendRequest(URL, PostData).GetResponseStream)
                Dim y As New IO.FileStream(FullFileName, IO.FileMode.Create)
                Dim z As New IO.BinaryWriter(y)
    
                Try ''// TODO: I can do better here
                    While True
                        z.Write(x.ReadByte)
                    End While
                Catch ''//continue
                End Try
    
                z.Flush()
                z.Close()
            Catch
                Return False
            End Try
            Return True
        End Function
        Function SaveResponseToFile(ByVal FullFileName As String, ByVal URL As String, Optional ByVal PostData As String = "") As Boolean
            Dim URL2 As Uri = Nothing
            If Uri.TryCreate(URL, UriKind.Absolute, URL2) Then
                Return SaveResponseToFile(FullFileName, URL2, PostData)
            Else : Return False
            End If
        End Function
        Function SaveResponseToFile(ByVal FullFileName As String, ByVal URL As String, ByRef PostData As Dictionary(Of String, String)) As Boolean
            Return SaveResponseToFile(FullFileName, URL, PrepPostData(PostData))
        End Function
        Function SaveResponseToFile(ByVal FullFileName As String, ByVal URL As Uri, ByRef PostData As Dictionary(Of String, String)) As Boolean
            Return SaveResponseToFile(FullFileName, URL, PrepPostData(PostData))
        End Function
    #End Region
    
    #Region "Get Image"
        Public Function GetImage(ByVal URL As String) As System.Drawing.Image
            Try
                GetImage = System.Drawing.Image.FromStream(SendRequest(URL).GetResponseStream)
            Catch
                GetImage = Nothing
            End Try
        End Function
        Public Function GetImage(ByVal URL As Uri) As System.Drawing.Image
            Try
                GetImage = System.Drawing.Image.FromStream(SendRequest(URL).GetResponseStream)
            Catch
                GetImage = Nothing
            End Try
        End Function
    #End Region
    
    #Region "PostToURL"
        Public Sub PostToURL(ByVal URL As String, Optional ByVal PostData As String = "")
            SendRequest(URL, PostData)
        End Sub
        Public Sub PostToURL(ByVal URL As Uri, Optional ByVal PostData As String = "")
            SendRequest(URL, PostData)
        End Sub
        Public Sub PostToURL(ByVal URL As String, ByRef PostData As Dictionary(Of String, String))
            PostToURL(URL, PrepPostData(PostData))
        End Sub
        Public Sub PostToURL(ByVal URL As Uri, ByRef PostData As Dictionary(Of String, String))
            PostToURL(URL, PrepPostData(PostData))
        End Sub
    #End Region
    
    #Region "Private Methods"
        Private Function PrepPostData(ByRef PostData As Dictionary(Of String, String)) As String
            PrepPostData = ""  ''// TODO: properly encode post data
            For Each pair As KeyValuePair(Of String, String) In PostData
                PrepPostData += pair.Key & "=" & pair.Value & "&"
            Next pair
            PrepPostData = PrepPostData.Remove(PrepPostData.Length - 1)
        End Function
    
        Private Function SendRequest(ByVal URL As String, Optional ByVal PostData As String = "") As HttpWebResponse
            Dim URL2 As Uri = Nothing
            If Uri.TryCreate(URL, UriKind.Absolute, URL2) Then
                Return SendRequest(URL2, PostData)
            Else
                Return Nothing
            End If
        End Function
        Private Function SendRequest(ByVal URL As Uri, Optional ByVal PostData As String = "") As HttpWebResponse
            Dim Request As HttpWebRequest = HttpWebRequest.Create(URL)
    
            Request.CookieContainer = Cookies
            Request.Timeout = TimeOut
            Request.UserAgent = Agent
    
            If PostData.Length > 0 Then
                Request.Method = "POST" ''// TODO: allow explicitly setting METHOD and Content-type for request via properties
                Request.ContentType = "application/x-www-form-urlencoded"
                Dim sw As New IO.StreamWriter(Request.GetRequestStream())
                sw.Write(PostData)
                sw.Close()
            End If
    
            Return Request.GetResponse()
        End Function
    #End Region
    End Class
