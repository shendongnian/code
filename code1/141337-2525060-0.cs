     		foreach (var currentPropertyInformation in source.GetType().GetProperties())
    		{
    			if ((currentPropertyInformation.GetGetMethod() == null) || (currentPropertyInformation.GetSetMethod() == null)) 
					continue;
    			if (string.Compare(currentPropertyInformation.Name, "Item") != 0) // handle non-enumerable properties
    			{
    				// place this snippet in method and yield info?
    			}
    			else // handle enumerable properties
    			{
    			}
    		}
