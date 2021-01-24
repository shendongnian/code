    if (message.Value != null)
    {
        var user_selections = Newtonsoft.Json.JsonConvert.DeserializeObject<userselections>(message.Value.ToString());
    
        await context.PostAsync($"You selected {user_selections.choiceset1}!");
        context.Wait(MessageReceivedAsync);
    }
