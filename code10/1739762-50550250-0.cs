    using System.Windows.Forms;
    using Newtonsoft.Json.Linq;
    
    namespace JsonTreeView
    {
    	public static class JsonToTreeView
    	{
    		public static void Json2Tree(this TreeView treeView, string json, string group_name)
    		{
    			if (string.IsNullOrWhiteSpace(json))
    			{
    				return;
    			}
    			var obj = JObject.Parse(json);
    			AddObjectNodes(obj, group_name, treeView.Nodes);
    		}
    
    		public static void AddObjectNodes(JObject obj, string name, TreeNodeCollection parent)
    		{
                var node = new TreeNode(name);
                parent.Add(node);
    
                foreach (var property in obj.Properties())
    			{
    				AddTokenNodes(property.Value, property.Name, node.Nodes);
    			}
    		}
    
    		private static void AddArrayNodes(JArray array, string name, TreeNodeCollection parent)
    		{
    			var node = new TreeNode(name);
    			parent.Add(node);
    
    			for (var i = 0; i < array.Count; i++)
    			{
    				AddTokenNodes(array[i], $"[{i}]", node.Nodes);
    			}
    		}
    
    		private static void AddTokenNodes(JToken token, string name, TreeNodeCollection parent)
    		{
    		    switch (token)
    		    {
    		        case JValue _:
    		            parent.Add(new TreeNode($"{((JValue) token).Value}"));
    		            break;
    		        case JArray _:
    		            AddArrayNodes((JArray)token, name, parent);
    		            break;
    		        case JObject _:
    		            AddObjectNodes((JObject)token, name, parent);
    		            break;
    		    }
    		}
    	}
    }
