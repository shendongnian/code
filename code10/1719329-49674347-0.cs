    [Serializable]
    public class Dialog49665918 : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Type anything to get user question or 'debug' to get debug version");
            context.Wait(this.MessageReceivedAsync);
        }
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            var replyToConversation = activity.CreateReply("Select an option");
            replyToConversation.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            replyToConversation.Attachments = new List<Attachment>();
            var cardContentList = new Dictionary<string, string>();
            if (!"debug".Equals(activity.Text, StringComparison.InvariantCultureIgnoreCase))
            {
                cardContentList.Add("Shirt", System.Web.HttpContext.Current.Server.MapPath(@"~\imgs\shirt.jpg"));
                cardContentList.Add("shoes", System.Web.HttpContext.Current.Server.MapPath(@"~\imgs\shoes.jpg"));
            }
            else
            {
                cardContentList.Add("Shirt", "https://media.deparis.me/3257-tm_large_default/tshirt-homme-papa-cool-et-tatoue.jpg");
                cardContentList.Add("shoes", "https://assets.adidas.com/images/w_840,h_840,f_auto,q_auto/d4dd2144b22b41bfbbd5a7ff01674bb3_9366/Superstar_Shoes_White_C77153_01_standard.jpg");
            }
            
            foreach (var cardContent in cardContentList)
            {
                var cardImages = new List<CardImage>
                {
                    new CardImage(url: cardContent.Value)
                };
                var plButton = new CardAction()
                {
                    Value = "nike",
                    Type = "postBack",
                    Title = "shirt"
                };
                var cardButtons = new List<CardAction>
                {
                    plButton
                };
                var plCard = new HeroCard()
                {
                    Title = "nike",
                    Images = cardImages,
                    Buttons = cardButtons
                };
                var plAttachment = plCard.ToAttachment();
                replyToConversation.Attachments.Add(plAttachment);
            }
            await context.PostAsync(replyToConversation);
        }
    }
