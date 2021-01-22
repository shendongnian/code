    public static class nullpartials
    	{
    		public static MvcHtmlString NullPartial(this HtmlHelper helper, string Partial, string NullPartial, object Model)
    		{
    			if (Model == null)
    				return helper.Partial(NullPartial);
    			else
    				return helper.Partial(Partial, Model);
    		}
    
    		public static MvcHtmlString NullPartial(this HtmlHelper helper, string Partial, string NullPartial, object Model, ViewDataDictionary viewdata)
    		{
    			if (Model == null)
    				return helper.Partial(NullPartial, viewdata);
    			else
    				return helper.Partial(Partial, Model, viewdata);
    		}
    
    		public static void RenderNullPartial(this HtmlHelper helper, string Partial, string NullPartial, object Model)
    		{
    			if (Model == null)
    			{
    				helper.RenderPartial(NullPartial);
    				return;
    			}
    			else
    			{
    				helper.RenderPartial(Partial, Model);
    				return;
    			}
    		}
    
    		public static void RenderNullPartial(this HtmlHelper helper, string Partial, string NullPartial, object Model, ViewDataDictionary viewdata)
    		{
    			if (Model == null)
    			{
    				helper.RenderPartial(NullPartial, viewdata);
    				return;
    			}
    			else
    			{
    				helper.RenderPartial(Partial, Model, viewdata);
    				return;
    			}
    		}
    	}
