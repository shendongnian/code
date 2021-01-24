    public static T GridPosition<T>(T gridData) where T : IReSizeableGrid {
        if (gridData is Hex) {
            var hexGrid = (HexGrid) gridData;
            return (T)HexLibrary.WorldToHex(WorldPoint(Input.mousePosition, GroundPlane), hexGrid);
        }
        if (gridData is QuadGrid) {
            var quadGrid = (QuadGrid)gridData;
            return (T)Grid.Get(WorldPoint(Input.mousePosition, GroundPlane), quadGrid);
        }
        throw new Exception("Wrong type passed to GridPosition: "+gridData.GetType());
    }
