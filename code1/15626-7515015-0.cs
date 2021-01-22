    Geometry inputGeometry = new PathGeometry();
    var inputGeometryClone = inputGeometry.Clone(); // we need a clone since in order to
                                                    // apply a Transform and geometry might be readonly
    inputGeometryClone.Transform = new TranslateTransform(); // applying some transform to it
    var result = inputGeometryClone.GetFlattenedPathGeometry();
