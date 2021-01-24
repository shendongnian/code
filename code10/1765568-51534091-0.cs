    public Tree<string> Build(string text)
    {
    	var tree = new Tree<string>() { Value = text };
    	if (text.Length > 1)
    	{
    		tree.Add(Build(text.Substring(0, text.Length / 2)));
    		tree.Add(Build(text.Substring(text.Length / 2)));
    	}
    	return tree;
    }
    
    public class Tree<T> : List<Tree<T>>
    {
    	public T Value;
    	public override string ToString()
    	{
    		var r = $"\"{this.Value}\"";
    		if (this.Any())
    		{
    			r += $" [{String.Join(", ", this.Select(t => t.ToString()))}]";
    		}
    		return r;
    	}
    }
