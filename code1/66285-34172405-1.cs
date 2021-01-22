    Dim cl2 As CellLayout = TryCast(e.GridNode.GetCell(4).Layout.Clone(), CellLayout)
    
    cl2.SelectedColor = Color.Red
    cl2.FontColor = Color.Red
    cl2.BackgroundColor = Color.Blue
    cl2.BackgroundUse = True ' when is true background color change 
    e.GridNode.GetCell(4).Layout = cl2
