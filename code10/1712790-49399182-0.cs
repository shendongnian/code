    private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
    {
        var activity = await result as Activity;
    
        int length = (activity.Text ?? string.Empty).Length;
    
        if (activity.Text=="card")
        {
            var replymess = context.MakeMessage();
    
            String imgUrl = ImageToBase64();
    
            List <CardImage> cardImages = new List<CardImage>();
            cardImages.Add(new CardImage(url: imgUrl));
    
            ThumbnailCard plCard = new ThumbnailCard()
            {
                Title = "I'm a thumbnail card",
                Text = "test pic",
                Images = cardImages
            };
    
            Attachment plAttachment = plCard.ToAttachment();
    
            replymess.Attachments.Add(plAttachment);
    
            await context.PostAsync(replymess);
    
        }
        else
        {
            
            await context.PostAsync($"You sent {activity.Text} which was {length} characters");
        }
    
        context.Wait(MessageReceivedAsync);
    }
