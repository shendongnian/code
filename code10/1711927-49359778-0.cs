    Public Shared Sub init()
        Client = New TelegramBotClient(tocken)
        Dim ms As New MemoryStream(Encoding.ASCII.GetBytes(<Your Self-Signed SSL Key>))
        Dim cert As New FileToSend("SSL.pem", ms)
        Client.SetWebhookAsync("https://Your/WebHook", cert)
        With Client.GetMeAsync.Result
            BotID = .Id
            BotUserName = .Username
            Try
                BotPhotoID = Client.GetUserProfilePhotosAsync(.Id).Result.Photos.First.First.FileId
            Catch ex As Exception
            End Try
        End With
    End Sub
