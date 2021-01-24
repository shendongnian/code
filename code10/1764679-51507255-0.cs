    public async Task ChoiceReceivedAsync(IDialogContext context, IAwaitable<booleanChoice> result)
    {
        booleanChoice response = await result;
        if (response.Equals(booleanChoice.Yes))
        {
            //send the inputs to the databse}
        else 
        {
            //exit or enter the message again
        }
    }
