    private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
    {
            CustomerDetails form = new CustomerDetails();
            FormDialog<CustomerDetails> customerForm = new FormDialog<CustomerDetails>(form, CustomerDetails.BuildForm, FormOptions.PromptInStart);
            context.Call(customerForm, FormSubmitted);
    }
    public async Task FormSubmitted(IDialogContext context, IAwaitable<CustomerDetails> result)
    {
            try
            {
                var form = await result;
               
            }
            catch (FormCanceledException<CustomerDetails> e)
            {
                string reply;
                if (e.InnerException == null)
                {
                    reply = $"Thanks for filling out the form.";
                }
                else
                {
                    reply = $"Sorry, I've had a short circuit.  Please try again.";
                }
                context.Done(true);
                await context.PostAsync(reply);
            }
     }
