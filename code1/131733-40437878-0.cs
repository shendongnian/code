    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Net;
    using System.IO;
    using System.Net.Mime;
    using System.Net.Mail;
    
    
    namespace ItsTrulyFree
    {
        public partial class demo_mail : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
        enter code here
            }
            protected void btnSubmit_Click(object sender, EventArgs e)
            {
    
                
                    MailMessage Msg = new MailMessage();
                    // Sender e-mail address.
                    Msg.From = new MailAddress(txtUsername.Text);
                    // Recipient e-mail address.
                    Msg.To.Add(txtTo.Text);
                    Msg.Subject = txtSubject.Text;
                    // File Upload path
                    String FileName = fileUpload1.PostedFile.FileName; 
    
    
                    string mailbody = txtBody.Text + "<br/><img src=cid:companylogo>";
    
                //LinkedResource LinkedImage = new LinkedResource(FileName);
                         //HttpContext.Current.Server.MapPath("/UploadedFiles");
                LinkedResource LinkedImage = new LinkedResource(Server.MapPath("~//" + FileName), "image/jpg");
                    LinkedImage.ContentId = "MyPic";
                    //Added the patch for Thunderbird as suggested by Jorge
                    LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);
    
                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailbody+
                      " <img src=cid:MyPic>",
                      null, "text/html");
    
                    htmlView.LinkedResources.Add(LinkedImage);
                    Msg.AlternateViews.Add(htmlView);
    
              
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential(txtUsername.Text, txtpwd.Text);
                    smtp.EnableSsl = true;
                    smtp.Send(Msg);
                    Msg = null;
                    Page.RegisterStartupScript("UserMsg", "<script>alert('Mail sent thank you...');if(alert){ window.location='SendMail.aspx';}</script>");
                }
                //catch (Exception ex)
                //{
                //    Console.WriteLine("{0} Exception caught.", ex);
                //}
            }
        
    }
