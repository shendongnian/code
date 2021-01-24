    var attachmentRequest = graphClient.Me.MailFolders.Inbox.Messages[message.Id]
                                    .Attachments[attachment.Id].Request().Expand("microsoft.graph.itemattachment/item").GetAsync();
    var itemAttachment = (ItemAttachment)attachmentRequest.Result;
    var itemMessage = (Message) itemAttachment.Item;  //get attached message
    Console.WriteLine(itemMessage.Body);  //print message body
