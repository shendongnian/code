    [Serializable]
    public class BalanceForm
    {
        public string contract_number;
    
        [Prompt("What is your contract number?")]
        public string contract;
    
        public string your_other_field;
        public static IForm<BalanceForm> BuildForm()
        {
            OnCompletionAsyncDelegate<BalanceForm> wrapUpRequest = async
            (context, state) =>
            {
                //using (BotModelDataContext BotDb = new BotModelDataContext())
                //{
                //    //search in database 
    
                //    string wrapUpMessage = "Dear " + house.Firstname + "," + "your  balance is " + house.Balance;
                //    await context.PostAsync(wrapUpMessage);
                //};
    
                //your code logic here
    
                var contractnumber = "";
    
                context.UserData.TryGetValue<string>("contract_number", out contractnumber);
    
                string wrapUpMessage = " Form completed! Your contract number is " + contractnumber;
                var replymes = context.MakeMessage();
                replymes.Text = wrapUpMessage;
    
                await context.PostAsync(replymes);
            };
    
            return new FormBuilder<BalanceForm>()
                .Message("We have to ask you some information")
                .Field(new FieldReflector<BalanceForm>(nameof(contract)).SetActive(state => state.contract_number == null))
                .Field(nameof(your_other_field))
                .OnCompletion(wrapUpRequest)
                //.Confirm("Are you sure: Yes or No ")
                .Build();
        }
    }
