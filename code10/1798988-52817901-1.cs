    public static object MyMethod(Association association , Person p)
    {
        MandrillApi mandrill = new MandrillApi(mandrillAPIKey);
        var mail = GetMandrillMessage(fromEmail, clubAdmin.ProfileInfo.Email);
        mail.AddGlobalVariable("Key", value);
        mail.AddGlobalVariable("Key", value);
        mail.AddGlobalVariable("AssociationBaseUrl", SettingsHelper.GetSetting("AssociationBaseUrl"));
        mail.AddGlobalVariable("Key", value);
        mail.AddGlobalVariable("UserFirstname", clubAdmin.Firstname);
        mail.Subject = "Subject goes here";
        var messageRequest = new SendMessageTemplateRequest(mail, "template");
        var result = mandrill.SendMessageTemplate(messageRequest);
        return result;
    }
    [HttpPost]
    public async Task<HttpResponseMessage> Post([FromBody]MyObject obj)
    {
       var task = Task.Run(() => MyMethod(a,p));   
       var result = await task;
       return Request.CreateResponse(...);
    }
