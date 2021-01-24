    [Serializable]
    public class RootDialog : IDialog<object>
    {
        private const string UserInfoRequestText = "YEP! Let's do that. \n\n\n\n Can you share with me below information's: \n\n\n\n 1) What is your name? \n\n\n\n 2) What is your email? \n\n\n\n 3) Date of Meeting (MM/DD/YYYY)? \n\n\n\n Share the information for future proceeding as example like below \n\n\n\n \"sujan#sujan@gmail.com#12/30/2018\"";
    
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
            return Task.CompletedTask;
        }
    
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            IMessageActivity message = await result as IMessageActivity;
    
            if (!context.UserData.ContainsKey("userinfo"))
            {
                PromptDialog.Text(context, AfterUserInfo, new PromptOptions<string>(UserInfoRequestText));
            }
            else
            {
                await context.Forward(new QnADialog(), AfterQnAMaker, message, CancellationToken.None);
            }
        }
    
        private async Task AfterQnAMaker(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            //allow the user to rate the qnamaker response here
        }
    
        private async Task AfterUserInfo(IDialogContext context, IAwaitable<string> result)
        {
            string text = await result;
    
            var values = text.Split('#');
            if (values.Count() < 3)
            {
                PromptDialog.Text(context, AfterUserInfo, new PromptOptions<string>(UserInfoRequestText));
                return;
            }
            else
            {
                UserProfile userProfile = new UserProfile();
                userProfile.Name = values[0];
                userProfile.Email = values[1];
                userProfile.Date = DateTime.Parse(values[2]);
                context.UserData.SetValue("userinfo", userProfile);
    
                await context.PostAsync($"Thanks {userProfile.Name}. What can we help you with?");
                
                SendEmail(userProfile);
                
                //context.Call(new QnADialog(), );
            }
        }
    
        public class UserProfile
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public DateTime Date { get; set; }
        }
    
        private static void SendEmail(UserProfile userProfile)
        {
            MailMessage mail = new MailMessage("you@yourcompany.com", userProfile.Email);
            SmtpClient client = new SmtpClient();
    
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            mail.Subject = "Email Subject";
            mail.Body = "Email body";
            
            //todo: actually send the email
            //client.Send(mail);
        }
    }
