    public void SetOpacity(Model3D model, double opacity)
    {
      var modelGroup = model as Model3DGroup;
      var geoModel = model as GeometryModel3D;
      if(modelGroup!=null)
        foreach(var submodel in modelGroup.Children)
          SetOpacity(submodel, opacity);
      if(geoModel!=null)
      {
        geoModel.Material = SetOpacity(geoModel.Material, opacity);
        geoModel.BackMaterial = SetOpacity(geoModel.BackMaterial, opacity);
      }
    }
    public Brush SetOpacity(Brush brush, double opacity)
    {
      if(!GetIsOpacityControlBrush(brush))  // Use attached property to mark brush
      {
        brush = new VisualBrush
        {
          Visual = new Rectangle { Fill = brush, ... };
        };
        SetIsOpacityControlBrush(brush, true);
      }
      ((Rectangle)((VisualBrush)brush).Visual).Opacity = opacity;
    }
