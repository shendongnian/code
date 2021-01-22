    // Creates the ResourceManager.
    System.Resources.ResourceManager myManager = new 
       System.Resources.ResourceManager("ResourceNamespace.myResources", 
       myAssembly);
    
    // Retrieves String and Image resources.
    System.String myString;
    System.Drawing.Image myImage;
    myString = myManager.GetString("StringResource");
    myImage = (System.Drawing.Image)myManager.GetObject("ImageResource");
