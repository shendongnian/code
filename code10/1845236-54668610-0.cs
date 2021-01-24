	public class Variant
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Subvariants> Subvariants { get; set; }
	}
	
	public class Subvariants
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
	
	public class ExecutionResult<T, TModel>
		where TModel : BaseModel<T>
	{
		public string Name { get; set; }
		public string ErrorMessage { get; set; }
		public bool Success { get; set; }
		public List<TModel> Types { get; set; }
	}
	
	public abstract class BaseModel<T>
	{
		public string Name { get; set; }
		public T Value { get; set; }
		public T Coordinates { get; set; }
		public decimal OverAllPercentage { get; set; }
	}
	
	public class Type1Model : BaseModel<int>
	{
		public decimal MiscPercentage { get; set; }
		public int PerformanceCounter { get; set; }
	}
	
	public class Type2Model : BaseModel<decimal> { }
	
	public abstract class BaseManager<T, TManager, TModel, R>
		where TManager : TypeBaseManager<T>
		where TModel : BaseModel<T>
		where R : ExecutionResult<T, TModel>, new()
	{
		protected abstract TManager CreateTypeManager(Variant model);
		protected abstract TModel CreateTypeModelLeft(TManager typeManager, Subvariants subvariant);
		protected abstract TModel CreateTypeModelRight(TManager typeManager, Subvariants subvariant);
		
		public R GetExecutionResult(Variant model)
		{
			var executionResult = new R();
			executionResult.Name = model.Name;
			var type1Result = new List<TModel>();
			try
			{
				for (int counter = 0; counter < model.Subvariants.Count - 1; counter++)
				{
					var left = model.Subvariants[counter];
					var right = model.Subvariants[counter + 1];
					using (var t = CreateTypeManager(model))
					{
						for (int i = 0; i < 2; i++)
						{
							if (i == 0)
							{
								t.Start(i);
								if (counter == 0)
								{
									type1Result.Add(CreateTypeModelLeft(t, left));
								}
							}
							else
							{
								t.Start(i);
								type1Result.Add(CreateTypeModelRight(t, right));
							}
						}
					}
				}
				executionResult.Types = type1Result;
			}
			catch (Exception ex)
			{
				executionResult.Success = false;
				executionResult.ErrorMessage = ex.Message;
			}
			return executionResult;
		}
	}
	
	public class Type1 : BaseManager<int, Type1Manager, Type1Model, ExecutionResult<int, Type1Model>>
	{
		protected override Type1Manager CreateTypeManager(Variant model)
		{
			return new Type1Manager(model);
		}
	
		protected override Type1Model CreateTypeModelLeft(Type1Manager typeManager, Subvariants subvariant)
		{
			return new Type1Model
	        {
	            Name = subvariant.Name,
	            Value = typeManager.Left
	        };
		}
	
		protected override Type1Model CreateTypeModelRight(Type1Manager typeManager, Subvariants subvariant)
		{
			return new Type1Model
	        {
	            Name = subvariant.Name,
	            Value = typeManager.Right,
	            Coordinates = typeManager.Left + typeManager.Right,
	            OverAllPercentage = typeManager.OverAllPercentage,
	            PerformanceCounter = (typeManager.NetPlus + typeManager.AverageRatio),
	            MiscPercentage = typeManager.MiscPercentage
	        };
		}
	}
	
	public class Type2 : BaseManager<decimal, Type2Manager, Type2Model, ExecutionResult<decimal, Type2Model>>
	{
		protected override Type2Manager CreateTypeManager(Variant model)
		{
			return new Type2Manager(model);
		}
	
		protected override Type2Model CreateTypeModelLeft(Type2Manager typeManager, Subvariants subvariant)
		{
			return new Type2Model { Name = subvariant.Name, Value = typeManager.Left };
		}
	
		protected override Type2Model CreateTypeModelRight(Type2Manager typeManager, Subvariants subvariant)
		{
			return new Type2Model
			{
	            Name = subvariant.Name,
	            Value = typeManager.Right,
	            Coordinates = typeManager.Left + typeManager.Right,
	            OverAllPercentage = typeManager.OverAllPercentage,
	        };
		}
	}
	
	public class TypeBaseManager<T> : IDisposable
	{
		protected Variant model;
		public T Right { get; private set; }
		public T Left { get; private set; }
		public decimal OverAllPercentage { get; private set; }
		public TypeBaseManager(Variant model)
		{
			this.model = model;
		}
	
		public void Start(int i)
		{
		}
	
		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
	
	public class Type1Manager : TypeBaseManager<int>
	{
		public int NetPlus { get; private set; }
		public int AverageRatio { get; private set; }
		public decimal MiscPercentage { get; private set; }
	
		public Type1Manager(Variant model) : base(model) { }
	}
	
	public class Type2Manager : TypeBaseManager<decimal>
	{
		public Type2Manager(Variant model) : base(model) { }
	}
