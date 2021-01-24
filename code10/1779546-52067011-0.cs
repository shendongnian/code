    EmailTemplateHelper templateHelper = new EmailTemplateHelper( HttpContext.Current.Request.MapPath("~/template_path/EMAIL_TEMPLATE.template"));
    Dictionary<string, string> replaceMapper = new Dictionary<string, string>() 
    {
        { "TAG1", emailInfo.name },
        { "TAG2", emailInfo.lastname}
                        
    };
    mailMessage.Subject = templateHelper.GetSubject(replaceMapper);
    mailMessage.Body = templateHelper.GetBody(replaceMapper);
    mailMessage.IsBodyHtml = true;
