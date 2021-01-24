        // Create the main window
        ContextSettings settings = new ContextSettings
        {
            DepthBits = 24,
            StencilBits = 8,
            AntialiasingLevel = 2, // optional
            MajorVersion = 3, // OpenGL version
            MinorVersion = 2, // OpenGL version
            AttributeFlags = ContextSettings.Attribute.Core
        };
        RenderWindow window = new RenderWindow(new VideoMode(800, 600), "SFML Works!", settings);
        window.setActive(true); //set the context as current
