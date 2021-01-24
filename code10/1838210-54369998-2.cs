    @functions{
        // Define a property to store the Action delegate 
        [Parameter] protected  Action<bool> onsubmit { get; set; } 
    
        // More code here...
    
        public async Task OnSubmitAsync() {
       var created = await this.service.CreateCampaignAsync(parameters);
            Console.WriteLine("Result of creation:" + created.ToString());
            // Call back the parent's method
            onsubmit?.Invoke(created);
        }
        
     }
