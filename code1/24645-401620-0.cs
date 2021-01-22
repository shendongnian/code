    //Namespace reference
    using System;
    using System.Resources;
    
    
    #region ReadResourceFile
    /// <summary>
    /// method for reading a value from a resource file
    /// (.resx file)
    /// </summary>
    /// <param name="file">file to read from</param>
    /// <param name="key">key to get the value for</param>
    /// <returns>a string value</returns>
    public string ReadResourceValue(string file, string key)
    {
        //value for our return value
        string resourceValue = string.Empty;
        try
        {
            // specify your resource file name 
            string resourceFile = file;
            // get the path of your file
            string filePath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            // create a resource manager for reading from
            //the resx file
            ResourceManager resourceManager = ResourceManager.CreateFileBasedResourceManager(resourceFile, filePath, null);
            // retrieve the value of the specified key
            resourceValue = resourceManager.GetString(key);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            resourceValue = string.Empty;
        }
        return resourceValue;
    }
    #endregion
