    myLayer.type = OSGeo.MapServer.MS_LAYER_TYPE.MS_LAYER_LINE;
    myLayer.status = 1;
    myLayer.symbolscaledenom = 1; 
    
    // Create a mapping class
    OSGeo.MapServer.classObj myClass = new OSGeo.MapServer.classObj(myLayer);
    // Create a style
    OSGeo.MapServer.styleObj style = new OSGeo.MapServer.styleObj(myClass);
                
    // unitColor = new Color(12, 34, 56);
    int red = Convert.ToInt32(unitColor.R);
    int green = Convert.ToInt32(unitColor.G);
    int blue = Convert.ToInt32(unitColor.B);
    style.color.setRGB(red, green, blue);
                
    style.outlinecolor.setRGB(255, 255, 255);
    //style.symbol = _map.symbolset.index("circle");  // Here '_map' is an instance of mapObj, this line is not strictly necessary 
                
    style.size = 10;
    style.minsize = 3; // Change this to your needs
             
