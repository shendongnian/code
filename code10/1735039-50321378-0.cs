    private void SetHeight(ListView listView, int height)
    {
        ImageList imgLst = new ImageList();
        imgLst.ImageSize = new Size(1, height);
        listView.SmallImageList = imgLst;
    }
