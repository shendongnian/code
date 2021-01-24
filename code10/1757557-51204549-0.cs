	public interface IHandler
	{
		void Run();
	}
	public abstract class BaseHandler<TObj> : IHandler
		where TObj: BaseType
	{
		protected readonly TObj _obj {get;set;}
		public BaseHandler(TObj obj)
		{
			this._obj = obj;
		}
		public abstract void Run();
	}
	public class DerivedHandler : BaseHandler<DerivedType>
	{
		public DerivedHandler(DerivedType obj) : base(obj)
		{
		}
		public override void Run()
		{
			// do stuff with base._obj
		}
	}
	public class HandlerService
	{
		public IHandler CreateHandler<TObj>(TObj obj)
		{
			// Depending on your DI container, you could resolve this automatically from the container
			if (typeof(TObj) == typeof(DerivedType))
			{
				return new DerivedHandler(obj);
			}
			throw new NotImplementedException();
		}
	}
	
