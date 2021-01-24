    void Init()
    {
        colorToAction.Add(PieceColor.white,
        delegate
        {
            GeneratePiece(whiteApplePrefab, 0, 0);
            GeneratePiece(whiteApplePrefab, 0, 1);
            GeneratePiece(whiteApplePrefab, 0, 2);
            GeneratePiece(whiteBananaPrefab, 1, 0);
            GeneratePiece(whiteBananaPrefab, 1, 1);
            GeneratePiece(whiteBananaPrefab, 2, 0);
            GeneratePiece(whiteBerryPrefab, 2, 2);
        });
    
        colorToAction.Add(PieceColor.blue,
        delegate
        {
            GeneratePiece(blueApplePrefab, 0, 0);
            GeneratePiece(blueApplePrefab, 0, 1);
            GeneratePiece(blueApplePrefab, 0, 2);
            GeneratePiece(blueBananaPrefab, 1, 0);
            GeneratePiece(blueBananaPrefab, 1, 1);
            GeneratePiece(blueBananaPrefab, 2, 0);
            GeneratePiece(blueBerryPrefab, 2, 2);
        });
    
        colorToAction.Add(PieceColor.red,
        delegate
        {
            GeneratePiece(redApplePrefab, 0, 0);
            GeneratePiece(redApplePrefab, 0, 1);
            GeneratePiece(redApplePrefab, 0, 2);
            GeneratePiece(redBananaPrefab, 1, 0);
            GeneratePiece(redBananaPrefab, 1, 1);
            GeneratePiece(redBananaPrefab, 2, 0);
            GeneratePiece(redBerryPrefab, 2, 2);
        });
    }
