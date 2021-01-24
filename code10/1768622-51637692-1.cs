    void Main()
    {
	    var mapperConfiguraiton = 
            new MapperConfiguration(cfg => 
                cfg.CreateMap<Widget, WidgetModel>()
                   .Increment(x => x.CountD, src => src.Count));
	    var widget = new Widget {Count = 3};
	    var mapper = mapperConfiguraiton.CreateMapper();
	
	    var model = mapper.Map<WidgetModel>(widget);
    }
    public class Widget {
	    public int Count {get; set;}
    }
    public class WidgetModel {
	    public int Count {get; set;}
    }
    public static class MapperExtensions {
	    public static IMappingExpression<TSource, TDestination> 
            Increment<TSource, TDestination, TDestinationMember>(
                this IMappingExpression<TSource, TDestination> expression, 
                Expression<Func<TDestination, TDestinationMember>> destinationMember, 
                Expression<Func<TSource, int>> sourceMember) 
        {
		    var param = Expression.Parameter(typeof(TSource));
		    var inv = Expression.Invoke(sourceMember, param);
		
		    var incr = Expression.Increment(inv);
				
		    var lambda = ((Expression<Func<TSource,int>>)Expression.Lambda(incr, param));
		
		    var newExpression = expression
                .ForMember(destinationMember, opts => opts.MapFrom(lambda));
		
		    return newExpression;
	    }
    }
