        public static Attachment GetHeroCard(string title, string subTitle, string text, List<CardImage> images, List<CardAction> action)
        {
            HeroCard card = new HeroCard();
            if (!String.IsNullOrEmpty(title))
                card.Title = title;
            if (!String.IsNullOrEmpty(subTitle))
                card.Subtitle = subTitle;
            if (!String.IsNullOrEmpty(text))
                card.Text = text;
            if (images != null)
                card.Images = images;
            if (action != null)
                card.Buttons =  action ;
            return card.ToAttachment();
        }
