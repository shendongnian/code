    if (results != null)
    {
        foreach (SearchResult result in results)
        {                    
            foreach(string propName in result.Properties.PropertyNames)
    		{
    			foreach(object myCollection in result.Properties[propName])
       			{
          			Console.WriteLine(propName + " : " + myCollection.ToString());
       			}
    		}
        }
    }
