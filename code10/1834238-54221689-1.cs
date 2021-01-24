    var request = graphClient.Me.MailFolders.Inbox.Messages.Request().Expand("attachments").GetAsync();
    var messages = request.Result;
    foreach (var message in messages)
    {
         foreach(var attachment in message.Attachments)
         {
              if (attachment.ODataType == "#microsoft.graph.itemAttachment")
              {
    
                  var attachmentRequest = graphClient.Me.MailFolders.Inbox.Messages[message.Id]
                                .Attachments[attachment.Id].Request().Expand("microsoft.graph.itemattachment/item").GetAsync();
                  var itemAttachment = (ItemAttachment)attachmentRequest.Result;
                  //...
              }
              else
              {
                   var fileAttachment = (FileAttachment)attachment;
                   System.IO.File.WriteAllBytes(System.IO.Path.Combine(downloadPath,fileAttachment.Name), fileAttachment.ContentBytes);
             }
         }
    }
