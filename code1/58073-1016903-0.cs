    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Collections;
    using System.Text;
    using System.Net;
    using System.Net.Mail;
    using System.Net.Mime; 
    //Mime is Not necerrary if you dont change the msgview and 
    //if you dont add custom/extra headers 
    using System.Threading;
    using System.IO;
    using System.Windows.Forms; // needed for MessageBox only.
    
    
    
    namespace BR.Util
    {
        public class Gmailer
        {
            
            SmtpClient client = new SmtpClient();
            static String mDefaultToAddress = "yourToAddress@yourdomain.com";
            static String mDefaultFromAddress = "anonymous@gmail.com";
            static String mDefaultFromDisplayName = "Anonymous";
   
            String mGmailLogin = "someaccount@gmail.com";
            String mGmailPassword = "yourpassword";
    
    
            public Gmailer()
            {
                client.Credentials = new System.Net.NetworkCredential(mGmailLogin, mGmailPassword);
                client.Port = 587;           
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.SendCompleted += new SendCompletedEventHandler(Gmailer_DefaultAsyncSendCompletedHandler);
            }
    
            public void setSendCompletedHandler(SendCompletedEventHandler pHandler)
            {
                client.SendCompleted -= Gmailer_DefaultAsyncSendCompletedHandler;
                client.SendCompleted += pHandler;
            }
    
            /// <summary>
            /// Static method which sends an email synchronously.
            /// It uses a hardcoded from email.
            /// </summary>
            /// <returns></returns>
            public static bool quickSend(String toEmailAddress, String subject, String body)
            {
                return Gmailer.quickSend(toEmailAddress, mDefaultFromAddress, mDefaultFromDisplayName, subject, body);
            }
    
            /// <summary>
            /// Static method which sends an email synchronously.
            /// It uses the hardcoded email address.
            /// </summary>
            /// <returns>true if successful, false if an error occurred.</returns>
            public static bool quickSend(String toEmailAddress, String fromEmailAddress,
                                         String fromDisplayName, String subject, String body)
            {
                try
                {
                    Gmailer gmailer = new Gmailer();
                    System.Net.Mail.MailMessage mailMsg = gmailer.createMailMessage(toEmailAddress, fromEmailAddress, fromDisplayName, subject, body);
                    gmailer.send(mailMsg);
                }
                catch (Exception ex)
                {
                    return false;
                }
                return true;
            }
    
            // <summary> creates a MailMessage object initialized with the default values.</summary>
            public System.Net.Mail.MailMessage createMailMessage()
            {
                return createMailMessage(mDefaultToAddress, mDefaultFromAddress, mDefaultFromDisplayName, mDefaultEmailSubject, mDefaultEmailBody);
            }
    
            public System.Net.Mail.MailMessage createMailMessage(String toEmailAddress, String fromEmailAddress, 
                                                                 String fromDisplayName, String subject, String body)
            {
                //Build The MSG
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                msg.To.Add(toEmailAddress);
                msg.From = new MailAddress(fromEmailAddress, fromDisplayName, System.Text.Encoding.UTF8);
                msg.Subject = subject;
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                msg.Body = body;
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.IsBodyHtml = false;
                msg.Priority = MailPriority.High;
                return msg;
            }
    
            public System.Net.Mail.MailMessage addAttachmentToMailMessage(System.Net.Mail.MailMessage msg, String attachmentPath)
            {
                msg.Attachments.Add(new Attachment(attachmentPath));
                return msg;
            }
    
            // <summary> method which blocks until the MailMessage has been sent.  Throws
            // System.Net.Mail.SmtpException if error occurs.</summary>
            public void send(System.Net.Mail.MailMessage pMailMessage)
            {
                //try {
                    client.Send(pMailMessage);
                //}
                //catch (System.Net.Mail.SmtpException ex)
                //{
                //    MessageBox.Show(ex.Message, "Send Mail Error");
                //}
            }
    
            // 
            public void sendAsync(System.Net.Mail.MailMessage pMailMessage)
            {
                object userState = pMailMessage;
                try
                {
                    MailSent = false;
                    client.SendAsync(pMailMessage, userState);
                }
                catch (System.Net.Mail.SmtpException ex)
                {
                    MessageBox.Show(ex.Message, "Send Mail Error");
                }
            }
    
            // <summary> 
            // Provides a default SendComplete handler which is activated when an AsyncCompletedEvent 
            // is triggered by the private client variable.  This is useful for debugging etc.
            // Use the method setSendCompletedHandler to define your own application specific handler.
            // That method also turns this handler off.
            // </summary>
            public void Gmailer_DefaultAsyncSendCompletedHandler(object sender, AsyncCompletedEventArgs e)
            {
                MailMessage mail = (MailMessage)e.UserState;
                string subject = mail.Subject;
    
                if (e.Cancelled)
                {
                    string cancelled = string.Format("[{0}] Send canceled.", subject);
                    MessageBox.Show(cancelled);                
                }
                if (e.Error != null)
                {
                    string error = String.Format("[{0}] {1}", subject, e.Error.ToString());
                    MessageBox.Show(error);                
                }
                else
                {
                    MessageBox.Show("Message sent.");
                }
                MailSent = true;
            }
    
           
            private bool _MailSent = false;
            /// <summary>
            /// Set to false when an async send operation is started and is set to true when finished.
            /// </summary>
            public bool MailSent
            {
                set
                {
                    _MailSent = value;
                }
                get
                {
                    return _MailSent;
                }
            }
        }
    }
