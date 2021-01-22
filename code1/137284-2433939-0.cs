        struct CameraSetting
        {
            public int Width
            { get; set; }
    
            public int Height
            { get; set; }
            public int Depth
            { get; set; }
        }
    
        struct TiltSettings
        {
            int Theta { get; set; }
            int Rho { get; set; }
        }
                XElement elements = XElement.Load("XMLFile.xml");
                var result = from e in elements.Descendants("cameraSettings")
                             select new CameraSetting
                             {
                                 Depth = Convert.ToInt32(e.Attribute("depth").Value),
                                 Height = Convert.ToInt32(e.Attribute("height").Value),
                                 Width = Convert.ToInt32(e.Attribute("width").Value)
    
                             };
