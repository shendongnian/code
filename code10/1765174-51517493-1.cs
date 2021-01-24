        /// <summary>
        /// Select features.
        /// </summary>
        /// <param name="map">Current map.</param>
        /// <param name="activeView">Instance of active view.</param>
        /// <param name="featurelayer">Layers to select features.</param>
        /// <param name="polygon">Polygon geometry to select features.</param>
        /// <returns>The count of selected features.</returns>
        public int SelectByPolygon(IMap map, IActiveView activeView, IFeatureLayer featurelayer, IGeometry polygon)
        {
            ISpatialFilter filter = new SpatialFilterClass();
            filter.Geometry = polygon;
            filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
            var featureSelection = (IFeatureSelection)featurelayer;
            featureSelection.SelectFeatures(filter, esriSelectionResultEnum.esriSelectionResultAdd, false);
            featureSelection.SelectionChanged();
            activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, activeView.Extent);
            ISelectionEvents selectionEvents = (ISelectionEvents)map;
            selectionEvents.SelectionChanged();
            return map.SelectionCount;
        }
