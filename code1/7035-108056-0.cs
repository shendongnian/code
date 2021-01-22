    _SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
    _LargeImageList.ColorDepth = ColorDepth.Depth32Bit;
    _SmallImageList.ImageSize = new System.Drawing.Size(16, 16);
    _LargeImageList.ImageSize = new System.Drawing.Size(32, 32);
    _IconListManager = new IconListManager(_SmallImageList, _LargeImageList);
    FileView.SmallImageList = _SmallImageList;
    FileView.LargeImageList = _LargeImageList;
