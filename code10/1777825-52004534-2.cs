    public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
    {
        var message = await result;
        if (message.Value != null)
        {
            //reroute the user back to your card with an additional message to 
            //put response in the provided fields.
            return;
        }
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
                IMessageActivity msg = Activity.CreateMessageActivity();
                msg.TextFormat = "text";
                msg.Text = _projectname;
                await context.Forward(new MyLuisDialog(), ResumeAfterLuisDialog, msg, CancellationToken.None);
            }
        }
    }
