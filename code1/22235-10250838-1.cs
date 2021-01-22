    public bool HandleError(Exception exception)
    		{
    			if (exception == null) return false;
    
    			var baseException = exception.GetBaseException();
    
    			Elmah.ErrorSignal.FromCurrentContext().Raise(baseException);
    			
    			if (!HttpContext.Current.IsCustomErrorEnabled) return false;
    			
    			try
    			{
    				
    				var behavior = _responseBehaviorFactory.GetBehavior(exception);
    				if (behavior != null)
    				{
    					behavior.ExecuteRedirect();
    					return true;
    				}
    			}
    			catch (Exception ex)
    			{
    				Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
    			}
    			return false;
    		}
