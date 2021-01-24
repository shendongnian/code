    public GridLayoutGroup gridLG;
    
    void Update()
    {
        int column = 0;
        int row = 0;
        GetColumnAndRow(gridLG, out column, out row);
        Debug.Log("Column: " + column + "   Row: " + row);
    }
