    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    namespace PlayAreaCSCon
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var mb = new DbModelBuilder();
    			mb.RegisterEntityType(typeof(Foo));
    			var pinfo = new DbProviderInfo("System.Data.SqlClient", "2008");
    			var ctx = new DbContext("Server=.;Database=Flange;Integrated Security=SSPI;",
                         mb.Build(pinfo).Compile());
    			ctx.Set<Foo>().Add(new Foo { ID = 1 });
    			ctx.SaveChanges();
    			Console.ReadKey();
    		}
    	}
    
    	public class Foo
    	{
    		public int ID { get; set; }
    	}
    }
