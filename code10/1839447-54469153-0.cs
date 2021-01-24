            public void Process(bool useGray)
            {
                if (useGray)
                {
                    DoStuff<Gray>(new Image<Gray, byte>(100, 100), new Image<Gray, byte>(10, 10));
                }
                else
                {
                    DoStuff<Bgr>(new Image<Bgr, byte>(100, 100), new Image<Bgr, byte>(10, 10));
                }
            }
    
            public void DoStuff<TColor>(Image<TColor, byte> window, Image<TColor, byte> pattern)
                where TColor : struct, IColor
            {
    
                using (var result = window.MatchTemplate(pattern, TemplateMatchingType.CcoeffNormed))
                {
                    result.MinMax(out var minValues, out var maxValues, out var minLocations, out var maxLocations);
    
                    //... evaluate matching
                }
            }
