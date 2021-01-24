       BlockingCollection<Bitmap> incomingBitmaps = new BlockingCollection<Bitmap>();
       BlockingCollection<Bitmap> processedBitmaps = new BlockingCollection<Bitmap>();
    public static void  SpawnThreads()
     {
     List<Task> ReaderTasks = new List<Task>();
    TaskFactory tfReader = new TaskFactory();
    
    public List<Task> ProcessTasks = new List<Task>();
    public TaskFactory tfProcess = new TaskFactory();
    
    //you can create threads as many you want
     for (int i = 0; i <2; i++)
     {
    ReaderTasks .Add(tfReader.StartNew(() => ReadBitmaps());
    }
     for (int i = 0; i <5; i++)
     {
    ProcessTasks.Add(tfProcess.StartNew(() => MedianFiltering());
    }
    }
    public static void ReadBitmaps()
        {
    //logic to get bitmap images
    Bitmap bmp= GetBitmapImage();
    incomingBitmaps.Add(bmp);
    }
    public static void MedianFiltering()
        {
     foreach (var bm in incomingBitmaps.GetConsumingEnumerable())
                {
            List<byte> termsList = new List<byte>();
    
            byte[,] image = new byte[bm.Width, bm.Height];
    
            //applying Median Filtering 
            for (int i = 0; i <= bm.Width - 3; i++)
                for (int j = 0; j <= bm.Height - 3; j++)
                {
                    for (int x = i; x <= i + 2; x++)
                        for (int y = j; y <= j + 2; y++)
                        {
                            termsList.Add(image[x, y]);
    
                        }
                    byte[] terms = termsList.ToArray();
                    termsList.Clear();
                    Array.Sort<byte>(terms);
                    Array.Reverse(terms);
                    byte color = terms[4];
                    bm.SetPixel(i + 1, j + 1, Color.FromArgb(color, color, color));
                }
    processedBitmaps.Add(bm);
    }
        }
