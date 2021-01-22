    class Person
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public List<Person> Children { get; set; }
    }
I should see a tree like for an example instance:
    - root
      - FirstName: John
      - LastName: Smith
      - Children:
        - [0]
          - FirstName: Ann
          - LastName: Smith
It's rather difficult to use reflection and go over an object's properties and such. Luckily, we already have a library that does that - Newtonsoft.Json.
My trick is to serialize the object with Newtonsoft.Json, then deserialize with System.Web.Script.Serialization.JavaScriptSerializer.
JavaScriptSerializer returns ArrayLists and Dictionaries, which are pretty simple to go over and add to the tree.
Thanks to [this article](https://www.codeproject.com/Articles/630300/JSON-Viewer) which gave me some of the concept ideas.
Anyway, here's the entire code:
In XAML:
    <TreeView ItemsSource="{Binding TreeItemsSource}">
    	<TreeView.Resources>
    		<HierarchicalDataTemplate DataType="{x:Type local:TreeNode}" ItemsSource="{Binding Path=Children}">
    			<TreeViewItem>
    				<TreeViewItem.Header>
    					<StackPanel Orientation="Horizontal" Margin="-10,0,0,0">
    						<TextBlock Text="{Binding Path=Name}"/>
    						<TextBlock Text=" : "/>
    						<TextBox Text="{Binding Path=Value}" IsReadOnly="True"/>
    					</StackPanel>
    				</TreeViewItem.Header>
    			</TreeViewItem>
    		</HierarchicalDataTemplate>
    	</TreeView.Resources>
    </TreeView>
In ViewModel:
    public IEnumerable<TreeNode> TreeItemsSource
    {
    	get
    	{
    		TreeNode tree = TreeNode.CreateTree(SelectedSession);
    		return new List<TreeNode>() { tree };
    	}
    }
And the TreeNode class
    public class TreeNode
    {
    	public string Name { get; set; }
    	public string Value { get; set; }
    	public List<TreeNode> Children { get; set; } = new List<TreeNode>();
    
    	public static TreeNode CreateTree(object obj)
    	{
    		JavaScriptSerializer jss = new JavaScriptSerializer();
    		var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
    		Dictionary<string, object> dic = jss.Deserialize<Dictionary<string, object>>(serialized);
    		var root = new TreeNode();
    		root.Name = "session";
    		BuildTree2(dic, root);
    		return root;
    	}
    
    	private static void BuildTree2(object item, TreeNode node)
    	{
    		if (item is KeyValuePair<string, object>)
    		{
    			KeyValuePair<string, object> kv = (KeyValuePair<string, object>)item;
    			TreeNode keyValueNode = new TreeNode();
    			keyValueNode.Name = kv.Key;
    			keyValueNode.Value = GetValueAsString(kv.Value);
    			node.Children.Add(keyValueNode);
    			BuildTree2(kv.Value, keyValueNode);
    		}
    		else if (item is ArrayList)
    		{
    			ArrayList list = (ArrayList)item;
    			int index = 0;
    			foreach (object value in list)
    			{
    				TreeNode arrayItem = new TreeNode();
    				arrayItem.Name = $"[{index}]";
    				arrayItem.Value = "";
    				node.Children.Add(arrayItem);
    				BuildTree2(value, arrayItem);
    				index++;
    			}
    		}
    		else if (item is Dictionary<string, object>)
    		{
    			Dictionary<string, object> dictionary = (Dictionary<string, object>)item;
    			foreach (KeyValuePair<string, object> d in dictionary)
    			{
    				BuildTree2(d, node);
    			}
    		}
    	}
    
    	private static string GetValueAsString(object value)
    	{
    		if (value == null)
    			return "null";
    		var type = value.GetType();
    		if (type.IsArray)
    		{
    			return "[]";
    		}
    
    		if (value is ArrayList)
    		{
    			var arr = value as ArrayList;
    			return $"[{arr.Count}]";
    		}
    
    		if (type.IsGenericType)
    		{
    			return "{}";
    		}
    
    		return value.ToString();
    	}
    
    }
