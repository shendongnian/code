    [Test]
    public void Should_remove_first_occurrance_of_string() {
    
    	var source = "ProjectName\\Iteration\\Release1\\Iteration1";
    
    	Assert.That(
    		source.RemoveFirst("\\Iteration"),
    		Is.EqualTo("ProjectName\\Release1\\Iteration1"));
    }
    
    public static class StringExtensions {
    	public static string RemoveFirst(this string source, string remove) {
    		int index = source.IndexOf(remove);
    		return (index < 0)
    			? source
    			: source.Remove(index, remove.Length);
    	}
    }
