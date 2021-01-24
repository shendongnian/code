    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
    
            return Task.CompletedTask;
        }
    
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
    
            if (activity.Value != null)
            {
                dynamic value = activity.Value;
    
                //please make sure you can extract all of these values (myName, myEmail ... mydiscussionduration etc) from activity.Value
                string name = value.myName.ToString();
                string email = value.myEmail.ToString();
                string tel = value.myTel.ToString();
                string selectvalue = value.CompactSelectVal.ToString();
                string discussiondate = value.mydiscussiondate.ToString();
                string discussionduration = value.mydiscussionduration.ToString();
    
                System.Net.Mail.MailMessage message1 = new System.Net.Mail.MailMessage();
                message1.To.Add("xxxx@hotmail.com");
                message1.Subject = "Interview Schedule request from" + name;
                message1.From = new System.Net.Mail.MailAddress("alexzwz1211@gmail.com");
                message1.Body = "Name:" + name + "\n Email:" + email + "\nPhone:" + tel + "\nCalltype:" + selectvalue + "\nDiscussion Date:" + discussiondate + "\nDiscussiona Duration:" + discussionduration;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("xxxx@gmail.com", "xxxx");
                smtp.Send(message1);
            }
            else
            {
                //forward to Luis dialog
                await context.Forward(new BasicLuisDialog(), AfterLuis, activity, CancellationToken.None);
            }
    
            context.Wait(MessageReceivedAsync);
        }
    
        private async Task AfterLuis(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceivedAsync);
        }
    
        public async Task<string> GetCardText1(string cardName)
        {
            var path = System.Web.Hosting.HostingEnvironment.MapPath($"/Dialogs/{cardName}.json");
            if (!File.Exists(path))
                return string.Empty;
    
            using (var f = File.OpenText(path))
            {
                return await f.ReadToEndAsync();
            }
        }
    }
