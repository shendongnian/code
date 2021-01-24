    public class NativeTranslateModelBinder : IModelBinder
    {
    	public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
    	{
    		if (bindingContext.ModelType != typeof(NativeTranslateViewModel))
    		{
    			return false;
    		}
    
    		var task = Task.Run(async () =>
    		{
    			var model = new NativeTranslateViewModel();
    
    			if (!actionContext.Request.Content.IsMimeMultipartContent())
    			{
    				bindingContext.ModelState.AddModelError(bindingContext.ModelName, "WebRequeest content 'multipart/form-data' is valid");
    			}
    			else
    			{
    				var provider = await actionContext.Request.Content.ReadAsMultipartAsync();
    
    				var fileContent = provider.Contents.FirstOrDefault(n => n.Headers.ContentDisposition.Name.Equals("file"));
    				if (fileContent == null)
    				{
    					bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Section 'file' is missed");
    				}
    
    				var modelContent = provider.Contents.FirstOrDefault(n => n.Headers.ContentDisposition.Name.Equals("model"));
    				if (modelContent == null)
    				{
    					bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Section 'model' is missed");
    				}
    
    				if (fileContent != null && modelContent != null)
    				{
    					model = JsonConvert.DeserializeObject<NativeTranslateViewModel>(await modelContent.ReadAsStringAsync());
    					model.Text = "<NativeTranslation>";
    					model.FileData = await fileContent.ReadAsByteArrayAsync();
    					model.FileName = fileContent.Headers.ContentDisposition.FileName;
    				}
    			}
    
    			return model;
    		});
    
    		task.Wait();
    
    		bindingContext.Model = task.Result;
    		return true;
    	}
    }
