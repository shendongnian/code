    //outTable and usaCapsTable is given
    // Create the Interpolator
    InverseDistanceWeightedInterpolator idw = new InverseDistanceWeightedInterpolator();
    // Set the values
    idw.SearchRadius = 100; // in pixels
    idw.Exponent = 2;
    idw.MinPoints = 1;
    idw.MaxPoints = 1000;
    // Create a GridCreator and pass in the table to use for input, the column holding the data, the interpolator. 
    MapInfo.Raster.GridCreatorFromFeatures cg = new GridCreatorFromFeatures(usaCapsTable, "Pop_1990", idw, outTable);
    cg.CellWidth = new Distance(12.9, DistanceUnit.Mile);
    Inflection[] infl = new Inflection[5];
    infl[0] = new Inflection(8000, Color.Blue);
    infl[1] = new Inflection(121000, Color.Aquamarine);
    infl[2] = new Inflection(199000, Color.Green);
    infl[3] = new Inflection(298000, Color.Yellow);
    infl[4] = new Inflection(980000, Color.Red);
    // Create a grid Style to use and pass in the onflection points.
    cg.GridStyle = new GridStyle(infl, true, Color.White, true);
    // Now check if there is a current selection. If yes then use the objects to clip the grid against.
    if ((MapInfo.Engine.Session.Current.Selections.DefaultSelection.Count > 0) &&
        MapInfo.Engine.Session.Current.Selections.DefaultSelection[0].Count > 0)
    {
        MapInfo.FeatureProcessing.FeatureProcessor fp = new MapInfo.FeatureProcessing.FeatureProcessor();
        Feature clip = fp.Combine(MapInfo.Engine.Session.Current.Selections.DefaultSelection[0]);
        cg.ClippingGeometry = clip.Geometry;
    }
    else
    {
        cg.ClippingGeometry = null;
    }
    // Create the grid file.
    cg.CreateGrid();
