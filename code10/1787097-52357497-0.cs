    public class ShapeBinder : IModelBinder
    {
    	public object Bind(NancyContext context, Type modelType, object instance, BindingConfig configuration, params string[] blackList)
    	{
    		using (var sr = new StreamReader(context.Request.Body))
    		{
    			var json = sr.ReadToEnd();
    			if (json.Contains("SomeTriangleOnlyProp"))
    			{
    				var triangle = new Nancy.Json.JavaScriptSerializer().Deserialize<Triangle>(json);
    				return triangle;
    			}
    			else if (json.Contains("SomeSquareOnlyProp"))
    			{
    				var square = new Nancy.Json.JavaScriptSerializer().Deserialize<Square>(json);
    				return square;
    			}
    			else
    			{
    				var shape = new Nancy.Json.JavaScriptSerializer().Deserialize<Shape>(json);
    				return shape;
    			}
    		}
    	}
    
    	public bool CanBind(Type modelType)
    	{
    		return modelType == typeof(Shape);
    	}
    }
