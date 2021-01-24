    try{
        
          var update = context.News.SingleOrDefault(x => x.Id == model.Id);
        
          update.Title = model.Title;
          update.Text = model.Text;
          context.SaveChanges();
        
    }
    catch(DbEntityValidationException ex)
    {
        	StringBuilder result = new StringBuilder();
        	var entityErrors = ex.EntityValidationErrors;
        	foreach (var entity in entityErrors)
        	{
        		foreach (var error in entity.ValidationErrors)
        		{
        			result.Append(error.PropertyName + " - " + error.ErrorMessage + "\n");
        		}
        	}		 
        	throw;
    }
