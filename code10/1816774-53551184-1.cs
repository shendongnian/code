    List<CroppedBitmap> tileImageList;
    Image imageBox;
    public TileFrame(MainWindow mWindow)
    {
        tileImageList = new List<CroppedBitmap>();
        imageBox = mWindow.ImageBox;
        PopTileList();
    }
    void PopTileList()
    {
        const int SIZE = 32;
        var bitmapImage = (BitmapSource)imageBox.Source;         
        for (int y = 0; y < 48; y++)
        {
            for (int x = 0; x < 64; x++)
            {
                var portion = new CroppedBitmap(bitmapImage, new Int32Rect((x * SIZE), (y * SIZE), SIZE, SIZE));                       
                tileImageList.Add(portion);                 
            }
        }        
    }
    public void ShowTilePic(int selectedId)
    {
        imageBox.Source = tileImageList[selectedId];
    }
