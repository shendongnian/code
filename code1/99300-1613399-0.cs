    for (int i = 0; i < 10; i++)
    {
          TorrentItem[i] = new TorrentItem(); //Initialize each element of the array
          test = i.ToString();
          TorrentItem[i].SetTorrentName(test); //I get a null reference error here. 
          //What am I doing wrong?
    }
