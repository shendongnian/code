    listView1.LargeImageList = Imagelist;
    listView1.SmallImageList = Imagelist;
    for (int j = 0; j < Stan.listaStanova.Count; j++)
    {
           
         WebClient wc = new WebClient();
         byte[] bytes = wc.DownloadData(Stan.listaStanova[j].linkSlike);
         MemoryStream ms = new MemoryStream(bytes);
         System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
         imagelist.Images.Add(img);
         ms.Dispose();
         // IN THIS CASE, WE'RE ASSUMING EACH LIST ITEM HAS A DISTINCT IMAGE
         // SO COUNT OF IMAGE COLLECTION IS SAME AS LISTVIEWITEMCOLLECTION
         // SO IMAGEINDEX PROPERTY IS ALWAYS THE J
         listView1.Items.Add(Stan.listaStanova[j].ToString(),j);                         
    }
