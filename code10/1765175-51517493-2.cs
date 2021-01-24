        protected override void OnClick()
        {
            try
            {
                IMxDocument document = (IMxDocument)ArcMap.Document;
                IMap map = document.FocusMap;
                IActiveView activeView = document.ActiveView;
                if (map.SelectionCount != 1)
                {
                    MessageBox.Show("Select one polygon.");
                    return;
                }
                // Get the polygon for selecting features
                IEnumFeature features = (IEnumFeature)map.FeatureSelection;
                IFeature feature = features.Next();
                IGeometry geometry = feature.ShapeCopy;
                if (geometry.GeometryType != esriGeometryType.esriGeometryPolygon)
                {
                    MessageBox.Show("Select one polygon.");
                    return;
                }
                // Find layer to select features
                UID uid = new UIDClass() { Value = typeof(IFeatureLayer).GUID.ToString("B") };
                IEnumLayer layers = map.get_Layers(uid);
                string layerName = "Name of your points layer to select";
                ILayer layer = null;
                IFeatureLayer featureLayer = null;
                while ((layer = layers.Next()) != null)
                {
                    if (layer.Name == layerName)
                    {
                        featureLayer = (IFeatureLayer)layer;
                        break;
                    }
                }
                map.ClearSelection();
                SelectByPolygon(featureLayer, geometry);
                activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, activeView.Extent);
                ISelectionEvents selectionEvents = (ISelectionEvents)map;
                selectionEvents.SelectionChanged();
                MessageBox.Show(string.Format("Number of selected features is {0}", map.SelectionCount));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Select features.
        /// </summary>
        /// <param name="featurelayer">Layers to select features.</param>
        /// <param name="polygon">Polygon geometry for select features.</param>
        public void SelectByPolygon(IFeatureLayer featurelayer, IGeometry polygon)
        {
            ISpatialFilter filter = new SpatialFilterClass();
            filter.Geometry = polygon;
            filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
            var featureSelection = (IFeatureSelection)featurelayer;
            featureSelection.SelectFeatures(filter, esriSelectionResultEnum.esriSelectionResultNew, false);
            featureSelection.SelectionChanged();
        }
