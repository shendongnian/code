	public class Task
	{
	}
     public interface IAppServerPlugin     
	 {        
		 void Register();        
		 void DispatchTaskToPlugin(Task t);        
	 }
	abstract public class BasePlugin : MarshalByRefObject, IAppServerPlugin    
	{
		public abstract void Register();
		void IAppServerPlugin.DispatchTaskToPlugin(Task t)
		{
		} 
	}
	public class Plugin : BasePlugin    
	{       
		override public void Register()        
		{             
		}   
		public void Something()
		{
			this.DispatchTaskToPlugin(null); // Doesn't compile
			base.DispatchTaskToPlugin(null); // Doesn't compile
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Plugin x;
			x.DispatchTaskToPlugin(null); // Doesn't compile
		}
	}
