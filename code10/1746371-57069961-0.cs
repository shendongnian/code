private bool AddNewSurfaceStyle(IfcBuildingElement element)
        {
            var representations = element.Representation.Representations;
            if (representations.Count == 0) return false;
            var body = representations.FirstOrDefault(a => a.RepresentationType == "SweptSolid");
            if (body == null) return false;
            var extrudedAreaSolid = body.Items.FirstOrDefault(a => a is IIfcExtrudedAreaSolid);
            if (extrudedAreaSolid == null) return false;
            var elementStyle = extrudedAreaSolid.StyledByItem.FirstOrDefault();
            using (var txn = element.Model.BeginTransaction("Create Style"))
            {
                var styleAssignment = element.Model.Instances.New<IfcPresentationStyleAssignment>();
                var surfaceStyle = element.Model.Instances.New<IfcSurfaceStyle>();
                var surfaceStyleRedering = element.Model.Instances.New<IfcSurfaceStyleRendering>();
                var colourRGB = element.Model.Instances.New<IfcColourRgb>();
                colourRGB.Blue = 1;
                colourRGB.Red = 1;
                colourRGB.Green = 0;
                surfaceStyleRedering.Transparency = 0;
                surfaceStyleRedering.SurfaceColour = colourRGB;
                surfaceStyle.Styles.Add(surfaceStyleRedering);
                styleAssignment.Styles.Add(surfaceStyle);
                elementStyle.Styles.Clear();
                elementStyle.Styles.Add(styleAssignment);
                txn.Commit();
            }
            return true;
        }
  [1]: http://docs.xbim.net/examples/proper-wall-in-3d.html
