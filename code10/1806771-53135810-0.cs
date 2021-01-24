         public event Action<string> DisplayAlert;
        		
           protected override async Task OnInitAsync()
           {
                var response = await Http.PostJsonAsync<Response>     ("/api/sessions/create", null);
            	
                if (response.StatusCode == HttpStatusCode.OK)
                {
                   // Success should be here, I believe
            	   NotifyStateChanged(response.Message);
                }
                else
                {
                    
                }
            }
    	
    	//Invoke any methods added to the event delegate:
      
       
    
    private void NotifyStateChanged(string message) =>  DisplayAlert?.Invoke(message);
	 
