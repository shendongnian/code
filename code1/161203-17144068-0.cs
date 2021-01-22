enter code here
    AttachmentCreationInformation newAtt = new AttachmentCreationInformation();
    newAtt.FileName = "myAttachment.txt";
    // create a file stream
    string fileContent = "This file is was ubloaded by client object meodel ";
    System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
    byte[] buffer = enc.GetBytes(fileContent);
    newAtt.ContentStream = new MemoryStream(buffer);
    // att new item or get existing one
    ListItem itm = list.GetItemById(itemId);
    ctx.Load(itm);   
    // do not execute query, otherwise a "version conflict" exception is rised, but the file         is uploaded
    // add file to attachment collection
    newAtt.ContentStream = new MemoryStream(buffer);
    itm.AttachmentFiles.Add(newAtt); 
    AttachmentCollection attachments = itm.AttachmentFiles;
    ctx.Load(attachments);
    ctx.ExecuteQuery(); 
    // see all attachments for list item
    // this snippet works if the list item has no attachments
