    ListView listView = new ListView();
    ImageList imageList = new ImageList();
    // add image to list:
    imageList.Images.Add("image_key", image_path);
    // give the listview the imagelist:
    listView.SmallImageList = imageList;
    // add item to listview:
    listView.Items.Add("item_text", "image_key");
