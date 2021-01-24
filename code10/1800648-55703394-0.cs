void Main()
{
	var cwd = Util.MyQueriesFolder;
	var args = new[] {
		"-noheader", 
		$"-work:{cwd}"
	};
	
	Console.SetOut(new NoDisposeTextWriter(Console.Out));
	Console.SetError(new NoDisposeTextWriter(Console.Error));
	new AutoRun(Assembly.GetExecutingAssembly()).Execute(args);
}
public class Foo{...}
[TextFixture]
public class TestFoo{...}
 
