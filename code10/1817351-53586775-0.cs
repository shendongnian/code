    var message = (EmailMessage) Item.Bind(service, new ItemId(uniqueId), PropertySet.FirstClassProperties);
    var reply = message.CreateReply(false);
    reply.BodyPrefix = "Response text goes here";
    var replyMessage = reply.Save(WellKnownFolderName.Drafts);
    replyMessage.Attachments.AddFileAttachment("d:\\inbox\\test.pdf");
    replyMessage.Update(ConflictResolutionMode.AlwaysOverwrite);
    replyMessage.SendAndSaveCopy();
