    [Test]
    public void Verify()
    {
    	var code =
    		@"namespace Debuggable
    		{
    			public class HelloWorld
    			{
    				public string Greet(string name)
    				{
    					var result = ""Hello, "" + name;
    					return result;
    				}
    			}
    		}
    		";
    
    	var codeGenerator = new CodeGenerator();
    	var assembly = codeGenerator.CreateAssembly(code);
    
    	dynamic instance = assembly.CreateInstance("Debuggable.HelloWorld");
    
    	// Set breakpoint here
    	string result = instance.Greet("Roslyn");
    
    	result.Should().Be("Hello, Roslyn");
    }
