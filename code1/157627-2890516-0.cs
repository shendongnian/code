		public Type Type {get; protected set;}
		public Object Value {get;protected set;}
		public Variable(Object val)
		{
			Type = val.GetType();
			Value = val;
		}
		public Variable(Type t, Object val)
		{
			Type = t;
			Value = val;
		}
	}
	
	public class ComposableFunction
	{
		public NUM_PARAMS NumParams { get; protected set; }
		public FUNCTION_NAME Name { get; protected set; }
		
		//our function signature
		public List<Type> ParamTypes { get; protected set; }
		public Type ReturnType { get; protected set; }
		
		private Delegate Function { get; set; }
		public Metadata (Delegate function)
		{
			Function = function;
		}
		public bool CanCallWith(params Variable vars)
		{
			return CanCallWith(vars);
		}
		public bool CanCallWith(IEnumerable<Variable> vars)
		{
			using(var var_enum = vars.GetEnumerator())
			using(var sig_enum = ParamTypes.GetEnumerator())
			{
				bool more_vars = false;
				bool more_sig =false;
				while(   (more_sig = sig_enum.MoveNext()) 
				      && (more_vars = var_enum.MoveNext())
				      && sig_enum.Current.IsAssignableFrom(var_enum.Current.Type));
				if(more_sig || more_vars)
					return false;
			}
			return true;
		}
		
		public Variable Invoke(params Variable vars)
		{
			return Invoke(vars);
		}
		public Variable Invoke(IEnumerable<Variable> vars)
		{
			return new Variable(ReturnType, Function.DynamicInvoke(vars.Select(v => v.Value)));
		}
	}
