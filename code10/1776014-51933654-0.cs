    const long TargetChannelId = 123456;
    static readonly ConcurrentDictionary<int, string[]> Answers = new ConcurrentDictionary<int, string[]>();
    private static async void Bot_OnMessage(object sender, MessageEventArgs e)
    {
        Message message = e.Message;
        int userId = message.From.Id;
    
        if (message.Type == MessageType.Text)
        {
            if (Answers.TryGetValue(userId, out string[] answers))
            {
                if (answers[0] == null)
                {
                    answers[0] = message.Text;
                    await Bot.SendTextMessageAsync(message.Chat, "Now send me your age");
                }
                else if (answers[1] == null)
                {
                    answers[1] = message.Text;
                    await Bot.SendTextMessageAsync(message.Chat, "Now send me your message");
                }
                else
                {
                    Answers.TryRemove(userId, out string[] _);
                    await Bot.SendTextMessageAsync(message.Chat, "Thank you, that's all I need from you");
    
                    string answersText = $"User {answers[0]}, aged {answers[1]} sent the following message:\n{message.Text}";
                    await Bot.SendTextMessageAsync(TargetChannelId, answersText);
                }
            }
            else
            {
                Answers.TryAdd(userId, new string[2]);
                await Bot.SendTextMessageAsync(message.Chat, "Please send me your name");
            }
        }
    }
