    Stopwatch watch = Stopwatch.StartNew();
    
    string filePath = @"C:\TestImage25k.png";
    
    Image fromFile = Image.FromFile(filePath);
    
    watch.Stop();
    
    Console.WriteLine("Image.FromFile     Ticks = {0:n}", watch.ElapsedTicks);
    
    long fromFileTicks = watch.ElapsedTicks;
    
    watch.Reset();
    watch.Start();
    
    Image fastImage = ImageFast.FromFile(filePath);
    
    watch.Stop();
    
    long fastFileTicks = watch.ElapsedTicks;
    
    Console.WriteLine("ImageFast.FromFile Ticks = {0:n}", watch.ElapsedTicks);
    
    Console.WriteLine("fromFileTicks - fastFileTicks = {0:n}", fromFileTicks - fastFileTicks);
