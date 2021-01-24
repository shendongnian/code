    [LuisIntent("Report")]
    public async Task ReportCompleteIntent(IDialogContext context, LuisResult result)
    {
            OutOfStockReport form = new OutOfStockReport();
    	    EntityRecommendation location;
            EntityRecommendation POS;
    	
            if(result.TryFindEntity("Weather.Location", out location))
    	    {
    		//Here you are initializing the form with values.
    		//If you have written any validation code for this field then
    		//formflow will check the validation when the form is called
    
    		     form.Location = location.Entity;
    	    }
            if(result.TryFindEntity("POS", out POS))
    	    {
    		     form.POS = POS.Entity;
    	    }
    	
    	    context.Call(form,OutOfStockReport.BuildForm, FormOptions.PromptInStart,OOSDialogComplete);
            
    }
