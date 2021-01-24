    public void PickNextNavPoint() {
        MoveIndex(1);
    }
    
    public void PickPreviousNavPoint() {
        MoveIndex(-1)
    }
    
    private void MoveIndex(delta) {
        navIndex += delta;
        // Constrain navIndex between 0 and len - 1
        navIndex = Math.Min(Math.Max(0, navIndex), myNavPoints.Length - 1);
    }
