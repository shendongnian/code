    public override void UpdatePosition(GridManager gameGrid) {
        vecPos = GameObject.Find("WUZ(Clone)").transform.position;
        Debug.Log(this + " the grid: " + gameGrid);
        position = gameGrid.GetNode((int)vecPos.x, (int)vecPos.y);
    }
