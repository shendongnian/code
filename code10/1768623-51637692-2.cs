    void Main()
    {
	    var mapperConfiguraiton = 
            new MapperConfiguration(cfg => 
                cfg.CreateMap<Widget, WidgetModel>()
                   .Increment(x => x.CountD, src => src.Count)
                   .ToUpper(x => x.Name, src=>src.Name));
	    var widget = new Widget {Count = 3, Name="Jimmy"};
	    var mapper = mapperConfiguraiton.CreateMapper();
	
	    var model = mapper.Map<WidgetModel>(widget);
    }
    public class Widget {
	    public int Count {get; set;}
        public string Name {get;set;}
    }
    public class WidgetModel {
	    public int Count {get; set;}
        public string Name {get;set;}
    }
    public static class MapperExtensions {
	    public static IMappingExpression<TSource, TDestination> Increment<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression, 
		    Expression<Func<TDestination, int>> destinationMember, 
		    Expression<Func<TSource, int>> sourceMember) 
	    {
		    return expression.CustomAction(destinationMember, sourceMember, s => s + 1);
	     }
	    public static IMappingExpression<TSource, TDestination> ToUpper<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression, 
		    Expression<Func<TDestination, string>> destinationMember, 
		    Expression<Func<TSource, string>> sourceMember)
	    {
		    return expression.CustomAction(destinationMember, sourceMember, s => s.ToUpper());
	    }
	    public static IMappingExpression<TSource, TDestination> CustomAction<TSource, TDestination, TDestinationMember, TSourceMember>(
		    this IMappingExpression<TSource, TDestination> expression, 
		    Expression<Func<TDestination, TDestinationMember>> destinationMember, 
		    Expression<Func<TSource, TSourceMember>> sourceMember, 
		    Expression<Func<TSourceMember, TDestinationMember>> transform)
	    {
		   var sourceMemberExpression = (MemberExpression)sourceMember.Body;		
		   var sourceParameter = Expression.Parameter(typeof(TSource));
		
		   var expr = Expression.Invoke(transform, 
									Expression
										.MakeMemberAccess(sourceParameter, sourceMemberExpression.Member));
				
		    var lambda = (Expression<Func<TSource,TSourceMember>>)
			    Expression.Lambda(expr, sourceParameter);
		
		    var newExpression = expression.ForMember(
			     destinationMember, 
			     opts => opts.MapFrom(lambda));
		
		    return newExpression;
	    }
    }
