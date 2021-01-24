            var activity = await result as Activity;
            var reply = activity.CreateReply();
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            List<Attachment> attachments = new List<Attachment>();
            List<Cars> cars = new List<Cars> {
                new Cars("This is a cool car", "car1"," title1", "1"),
                new Cars("This is an awesome car", "car2", " title2", "2"),
                new Cars("This is the best car", "car3", " title3", "3"),
                new Cars("This is the worst car", "car4", " title4", "4"),
                new Cars("This is amazing", "car5"," title5", "5")
            };
            foreach (Cars car in cars)
            {
                
                List<CardAction> buttons = new List<CardAction>();
                CardAction button = new CardAction(ActionTypes.PostBack, "Show car", value: car.Id);
                buttons.Add(button);
                var heroCard = new ThumbnailCard
                {
                    Title = car.Title ?? "",
                    Subtitle = car.Model ?? "2",
                    Text = $"{car.Description}" ?? $"Text is not available for this car.",
                    Buttons = buttons
                };
                ;
                attachments.Add(heroCard.ToAttachment());
            }
            reply.Attachments = attachments;
            try
            {
                await context.PostAsync(reply);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
