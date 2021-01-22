    public static object GetPropertyValue(object srcObj, string propertyName)
    {
      if (srcObj == null) 
      {
        return null; 
      }
      PropertyInfo pi = srcObj.GetType().GetProperty(propertyName.Replace("[]", ""));
      if (pi == null)
      {
        return null;
      }
      return pi.GetValue(srcObj);
    }
    public static void PropertyValues_byRecursion(string parentPath, object parentObj, bool showNullValues)
    {
      /// Processes all of the objects contained in the parent object.
      ///   If an object has a Property Value, then the value is written to the Console
      ///   Else if the object is a container, then this method is called recursively
      ///       using the current path and current object as parameters
      // Note:  If you do not want to see null values, set showNullValues = false
      foreach (PropertyInfo pi in parentObj.GetType().GetTypeInfo().GetProperties())
      {
        // Build the current object property's namespace path.  
        // Recursion extends this to be the property's full namespace path.
        string currentPath = parentPath + "." + pi.Name;
        // Get the selected property's value as an object
        object myPropertyValue = GetPropertyValue(parentObj, pi.Name);
        if (myPropertyValue == null)
        {
          // Instance of Property does not exist
          if (showNullValues)
          {
            Console.WriteLine(currentPath + " = null");
          }
        }
        else if (myPropertyValue.GetType().IsArray)
        {
          // myPropertyValue is an object instance of an Array of business objects.
          // Initialize an array index variable so we can show NamespacePath[idx] in the results.
          int idx = 0;
          foreach (object business in (Array)myPropertyValue)
          {
            if (business == null)
            {
              // Instance of Property does not exist
              // Not sure if this is possible in this context.
              if (showNullValues)
              {
                Console.WriteLine(currentPath  + "[" + idx.ToString() + "]" + " = null");
              }
            }
            else if (business.GetType().IsArray)
            {
              // myPropertyValue[idx] is another Array!
              // Let recursion process it.
              PropertyValues_byRecursion(currentPath + "[" + idx.ToString() + "]", business, showNullValues);
            }
            else if (business.GetType().IsSealed)
            {
              // Display the Full Property Path and its Value
              Console.WriteLine(currentPath + "[" + idx.ToString() + "] = " + business.ToString());
            }
            else
            {
              // Unsealed Type Properties can contain child objects.
              // Recurse into my property value object to process its properties and child objects.
              PropertyValues_byRecursion(currentPath + "[" + idx.ToString() + "]", business, showNullValues);
            }
            idx++;
          }
        }
        else if (myPropertyValue.GetType().IsSealed)
        {
          // myPropertyValue is a simple value
          Console.WriteLine(currentPath + " = " + myPropertyValue.ToString());
        }
        else
        {
          // Unsealed Type Properties can contain child objects.
          // Recurse into my property value object to process its properties and child objects.
          PropertyValues_byRecursion(currentPath, myPropertyValue, showNullValues);
        }
      }
    }
