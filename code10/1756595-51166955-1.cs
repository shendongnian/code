    private async Task ChoiceReceivedAsync(IDialogContext context, IAwaitable<string> result)
    {
        string response = await result;
    
        var customerdata = GetCustomerdata();
    
        //retrieve the id of selected option
        var id = customerdata.Where(p => p.ClientName == response).Select(r => r.Id).FirstOrDefault();
        //your business logic here
    
        await context.PostAsync($"Id is {id} and ClientName is {response}");
    }
