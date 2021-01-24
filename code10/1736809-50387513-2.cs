    byte[] file1 = Encoding.ASCII.GetBytes(str1.ToString());
    byte[] File = Encoding.ASCII.GetBytes(str.ToString());
    EmailDetails objEmail = new EmailDetails();
    var tomail = db.Parameters.ToList().Where(m => m.Name == "ToList" && 
    m.Category == "DynamicReport").FirstOrDefault().Value;
    objEmail.ToMailId = tomail;
    objEmail.Attachments = new List<AttachmentDetails>();
    var attachment = new AttachmentDetails();
    attachment.Name = "katalister_daily_report_" + DateTime.Now + ".xls";
    attachment.Content = File;
    objEmail.Attachments.Add(attachment);
    
    attachment = new AttachmentDetails();
    attachment.Name = "OrderDetails_BD.xls";
    attachment.Content = file1;
    objEmail.Attachments.Add(attachment);
    objEmail.Subject = "Katalister Dynamic Report";
    objEmail.Body = "&nbsp; Dear Leader,<br/><br/>   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Please find the attached Katalister Daily Report and Order Details Report.<br/><br/><br/><br/> Team Karvy";
    objEmail.CCList = db.Parameters.ToList().Where(m => m.Name == "CCList" && m.Category == "DynamicReport").FirstOrDefault().Value;
 
