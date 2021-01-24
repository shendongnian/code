    $code = 
    @'
    	using System;
    	using System.Linq.Expressions;
    
    	public class Entity
    	{
    		public string Property1 { get; set; }
    		public int Property2 { get; set; }
    	}
    
    	public class TestClass
    	{
    		public void Load<T>(T thing, params Expression<Func<T, object>>[] retrievals)
    		{
    			foreach (var retrieval in retrievals)
    			{
    				System.Console.WriteLine("Retrieval: " + retrieval);
    			}
    		}
    
    		private static Expression<Func<T, object>> FuncToExpression<T>(Func<T, object> f)  
    		{  
    			return x => f(x);  
    		} 
    		
    		public void Load2<T>(T thing, params Func<T, object>[] retrievals)
    		{
    			var funcs = new Expression<Func<T, object>>[retrievals.Length];
    
    			for (int i = 0; i < retrievals.Length; i++)
    			{
    				funcs[i] = FuncToExpression(retrievals[i]);
    			}
    
    			this.Load<T>(thing, funcs);
    		}
    		
    		public void Test1()
    		{
    			Entity entity = new Entity();
    			this.Load<Entity>(entity, e => e.Property1, e => e.Property2);
    		}
    	}
    '@
