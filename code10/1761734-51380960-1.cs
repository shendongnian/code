    PieceColor color = PieceColor.white;
    private void GenerateBoard()
    {
        Action action;
        if (colorToAction.TryGetValue(color, out action))
            action.Invoke();
    }
