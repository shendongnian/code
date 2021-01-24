    foreach (var item in myList)
    {
    	data.Add(new Items{ Content = new BitmapImage(new Uri(item, UriKind.Abslote)) });
    }
    
    cover.ItemSource = data;
