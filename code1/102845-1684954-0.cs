	// MethodMissingDemo.cs
	using System;
	using IronRuby;
	class Program
	{
		static void Main()
		{
			var rubyEngine = Ruby.CreateEngine();
			rubyEngine.ExecuteFile("method_missing_demo.rb");
			dynamic globals = rubyEngine.Runtime.Globals;
			dynamic methodMissingDemo = globals.MethodMissingDemo.@new();
			Console.WriteLine(methodMissingDemo.HelloDynamicWorld());
			methodMissingDemo.print_all(args);
		}
	}
    # method_missing_demo.rb
    class MethodMissingDemo
      def print_all(args)
        args.map {|arg| puts arg}
      end
      def method_missing(name, *args)
        name.to_s.gsub(/([[:lower:]\d])([[:upper:]])/,'\1 \2')
      end
    end
