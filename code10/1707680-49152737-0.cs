    using System.Collections.Generic;
    using Unity;
	class Program
	{
		static void Main(string[] args)
		{
			var container = new UnityContainer();
			container.RegisterType<IRule, RuleA>("a");
			container.RegisterType<IRule, RuleB>("b");
			container.RegisterType<IRule, RuleC>("c");
			container.RegisterType<IRule, RuleD>("d");
			container.RegisterType<IRule, RuleE>("e");
			container.RegisterType<IRuleExecutor, RuleExecutor>();
			var executor = container.Resolve<IRuleExecutor>();
		}
	}
	public interface IRule { }
	public class RuleA : IRule { }
	public class RuleB : IRule { }
	public class RuleC : IRule { }
	public class RuleD : IRule { }
	public class RuleE : IRule { }
	public interface IRuleExecutor { }
	public class RuleExecutor : IRuleExecutor
	{
		public RuleExecutor(IEnumerable<IRule> rules)
		{
			// Rules RuleA through RuleF are injected here...
		}
	}
