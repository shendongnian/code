    public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
    {
        var message = await result;
        InputValues data;
        if (message.Value != null)
        {
            // Got an Action Submit
            dynamic value = message.Value;
            string submitType = value.Type.ToString();
            if (value != null)
            {
                data = Newtonsoft.Json.JsonConvert.DeserializeObject<InputValues>(submitType);
                _projectname = data.Name;
                _description = data.Description;
                var msg = message.CreateMessage();
                msg.Type = "message";
                msg.Text = _projectname;
                await context.Forward(new MyLuisDialog(), ResumeAfterLuisDialog, msg, CancellationToken.None);
            }
        }
    }
