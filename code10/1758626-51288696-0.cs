          corners[0] -= w * ( XYZ.BasisX + XYZ.BasisY );
          corners[1] += w * ( XYZ.BasisX - XYZ.BasisY );
          corners[2] += w * ( XYZ.BasisX + XYZ.BasisY );
          corners[3] -= w * ( XYZ.BasisX - XYZ.BasisY );
          CurveArray profile = new CurveArray();
          for( int i = 0; i < 4; ++i )
          {
            Line line = Line.CreateBound( // 2014
              corners[i], corners[3 == i ? 0 : i + 1] );
            profile.Append( line );
          }
          List<Element> roofTypes
            = new List<Element>(
              LabUtils.GetElementsOfType(
                doc, typeof( RoofType ),
                BuiltInCategory.OST_Roofs ) );
          RoofType roofType = roofTypes
            .Cast<RoofType>()
            .FirstOrDefault<RoofType>( typ
              => null != typ.GetCompoundStructure() );
          ModelCurveArray modelCurves
            = new ModelCurveArray();
          FootPrintRoof roof
            = createDoc.NewFootPrintRoof( profile,
              levelTop, roofType, out modelCurves );
