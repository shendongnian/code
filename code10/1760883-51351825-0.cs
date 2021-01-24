    [HttpDelete]
    public async Task Delete()
    {
        using (StreamReader reader = new StreamReader(request.Body, encoding))
    	{
    		var bodyContent = await reader.ReadToEndAsync();
    		if(!String.IsNullOrEmpty(bodyContent))
    		{
    			//mapp the bodyContent to your model
    		}
    	}
    	//perform the logic which should allways be done
    }
