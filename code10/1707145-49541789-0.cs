    using System;
    using System.Net.Mail;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
     public partial class Form1 : Form
     {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
           try
            {
                MailMessage mail = new MailMessage();
                using (var smtpobj = new SmtpClient("smtp.gmail.com"))
                {
                    mail.To.Add("xxx@gmail.com");
                    mail.From = new MailAddress("yyy@gmail.com");
                    mail.Subject = "subject - .net app";
                    mail.Body = "body";
                    smtpobj.Port = 587;
                    smtpobj.Credentials = new System.Net.NetworkCredential("yyy@gmail.com", "xyz");
                    smtpobj.EnableSsl = true;
                    smtpobj.Send(mail);
                    smtpobj.ServicePoint.CloseConnectionGroup( 
                            smtpobj.ServicePoint.ConnectionName);
                }
            }
            catch(Exception ex)
            {
                string strReturn = ex.ToString();
                MessageBox.Show(strReturn);
            }
        }
      }
    }
