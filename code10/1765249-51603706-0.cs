    bool translate = true;
    using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, activity))
    {
        var botData = scope.Resolve<IBotData>();
        await botData.LoadAsync(default(CancellationToken));
    
        var stack = scope.Resolve<IDialogTask>();
        if (stack.Frames != null && stack.Frames.Count > 0)
        {
            var lastFrame = stack.Frames[stack.Frames.Count - 1];
            var frameValue = lastFrame.Target.GetType().GetFields()[0].GetValue(lastFrame.Target);
            if (frameValue.GetType() == typeof(FormDialog<SandwichOrder>))
            {
                //in the FormFlow dialog ... do NOT translate
                translate = false;
            }
        }
    }
    if (translate)
    {
        //translate activity.Text to English before sending to LUIS for intent
        activity.Text = TranslationHandler.TranslateTextToDefaultLanguage(activity, userLanguage);
    }
    await Conversation.SendAsync(activity, MakeRoot);
                        
