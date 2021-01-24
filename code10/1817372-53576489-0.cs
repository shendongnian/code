    try
    {
    	HttpResponseMessage response = KorisniciService.PostResponse(k);
    	
    	if (response.IsSuccessStatusCode)
    	{
    		MessageBox.Show(Messages.add_usr_succ);
    		DialogResult = DialogResult.OK;
    		Close();
    	}
    }
    catch(HttpResponseException ex)
    {
    	string message = ex.ReasonPhrase;
    	
    	if (string.IsNullOrEmpty(Messages.ResourceManager.GetString(ex.ReasonPhrase)))
    		message = Messages.ResourceManager.GetString(ex.ReasonPhrase);
    
    
    	MessageBox.Show("Error code: " + ex.StatusCode + " Message: " + message);
    }
