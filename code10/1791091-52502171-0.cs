            REngine.SetEnvironmentVariables();
            REngine engine = REngine.GetInstance();
            engine.Initialize();
            //string path = "\HelloWorld.r";
            //engine.Evaluate("source('" + path + "')");
            var x = engine.Evaluate("x <- 1 + 2");
        
