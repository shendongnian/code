    public static readonly DependencyProperty IsDraggingPieceProperty = DependencyProperty.RegisterAttached(
            "IsDraggingPiece",
            typeof(bool),
            typeof(MainWindow),
            new FrameworkPropertyMetadata(false
          , new PropertyChangedCallback(IsDraggingPieceChanged)
        ));
