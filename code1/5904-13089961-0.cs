    Outlook.Application mailApplication = new Outlook.Application();
    Outlook.NameSpace mailNameSpace = mailApplication.GetNamespace(“mapi”);
    // make sure it is an embedded item
    If(myAttachment.Type == Outlook.OlAttachmentType.olEmbeddeditem)
    {
        myAttachment.Type.SaveAsFile(“temp.msg”);
        Outlook.MailItem attachedEmail = (Outlook.MailItem)mailNameSpace.OpenSharedItem(“temp.msg”);
        String customProperty = attachedEmail.PropertyAccessor.GetProperty(
            “http://schemas.microsoft.com/mapi/string/{00020329-0000-0000-c000-000000000046}/myProp
    }
