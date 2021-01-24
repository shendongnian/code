    string max = string.Empty;
    int length=0;
    foreach(var item in list)
    {
        if(item.Length>length)
        {
            max = item;
            length = item.Length;
        }
    }
