    private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
    {
            var reply = context.MakeMessage();
            reply.Attachments.Add(GetAudioCard());
            await context.PostAsync(reply);
            context.Wait(MessageReceivedAsync);
    }
    private static Attachment GetAudioCard()
    {
        var audioCard = new AudioCard
        {
            Title = "Havana",
            Subtitle = "Camila Cabello",
            Image = new ThumbnailUrl
            {
                Url = "https://en.wikipedia.org/wiki/Havana_(Camila_Cabello_song)#/media/File:Havana_(featuring_Young_Thug)_(Official_Single_Cover)_by_Camila_Cabello.png"
            },
            Media = new List<MediaUrl>
            {
                new MediaUrl()
                {
                    Url = "http://213.32.113.82/music/Now%20Thats%20What%20I%20Call%20Running%20(2018)/CD1/02.%20Camila%20Cabello%20feat.%20Young%20Thug%20-%20Havana.mp3"
                }
            },
            Buttons = new List<CardAction>
            {
                new CardAction()
                {
                    Title = "Read More",
                    Type = ActionTypes.OpenUrl,
                    Value = "https://en.wikipedia.org/wiki/Havana_(Camila_Cabello_song)"
                }
            }
        };
        return audioCard.ToAttachment();
    }
