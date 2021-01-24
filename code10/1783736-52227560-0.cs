    namespace AutoMapper
    {
    	using System.Collections.Generic;
    	using System.Linq;
    	using System.Linq.Expressions;
    	using AutoMapper.Configuration.Internal;
    	using AutoMapper.Mappers.Internal;
    	using AutoMapper.QueryableExtensions;
    	using AutoMapper.QueryableExtensions.Impl;
    
    	public class GenericEnumerableExpressionBinder : IExpressionBinder
    	{
    		public bool IsMatch(PropertyMap propertyMap, TypeMap propertyTypeMap, ExpressionResolutionResult result) =>
    			propertyMap.DestinationPropertyType.IsGenericType &&
    			propertyMap.DestinationPropertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>) &&
    			PrimitiveHelper.IsEnumerableType(propertyMap.SourceType);
    
    		public MemberAssignment Build(IConfigurationProvider configuration, PropertyMap propertyMap, TypeMap propertyTypeMap, ExpressionRequest request, ExpressionResolutionResult result, IDictionary<ExpressionRequest, int> typePairCount, LetPropertyMaps letPropertyMaps)
    			=> BindEnumerableExpression(configuration, propertyMap, request, result, typePairCount, letPropertyMaps);
    
    		private static MemberAssignment BindEnumerableExpression(IConfigurationProvider configuration, PropertyMap propertyMap, ExpressionRequest request, ExpressionResolutionResult result, IDictionary<ExpressionRequest, int> typePairCount, LetPropertyMaps letPropertyMaps)
    		{
    			var expression = result.ResolutionExpression;
    
    			if (propertyMap.DestinationPropertyType != expression.Type)
    			{
    				var destinationListType = ElementTypeHelper.GetElementType(propertyMap.DestinationPropertyType);
    				var sourceListType = ElementTypeHelper.GetElementType(propertyMap.SourceType);
    				var listTypePair = new ExpressionRequest(sourceListType, destinationListType, request.MembersToExpand, request);
    				var transformedExpressions = configuration.ExpressionBuilder.CreateMapExpression(listTypePair, typePairCount, letPropertyMaps.New());
    				if (transformedExpressions == null) return null;
    				expression = transformedExpressions.Aggregate(expression, (source, lambda) => Select(source, lambda));
    			}
    
    			return Expression.Bind(propertyMap.DestinationProperty, expression);
    		}
    
    		private static Expression Select(Expression source, LambdaExpression lambda)
    		{
    			return Expression.Call(typeof(Enumerable), "Select", new[] { lambda.Parameters[0].Type, lambda.ReturnType }, source, lambda);
    		}
    
    		public static void InsertTo(List<IExpressionBinder> binders) =>
    			binders.Insert(binders.FindIndex(b => b is EnumerableExpressionBinder), new GenericEnumerableExpressionBinder());
    	}
    }
