public class WorkerArgs{
   public List<BitMapSource> _bitmapSources;
   public Twain _twain;
   public ScanSettings _settings;
}
List<BitmapSource> bitmapSources = new List<BitmapSource>();
Twain twain = new Twain(new WpfWindowMessageHook(_window));
ScanSettings settings = new ScanSettings() { ShowTwainUI = false };
WorkerArgs wArgs = new WorkerArgs();
wArgs._bitmapSources = bitmapSources;
wArgs._twain = twain;
wArgs._settings = settings;
using (BackgroundWorker worker = new BackgroundWorker())
{
    worker.DoWork += new DoWorkEventHandler(worker_DoWork);
    worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
    worker.RunWorkerAsync((WorkerArgs)wArgs);
}
void  worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
{
   try{
    image1.Source = (WorkerArgs(e.Argument))._bitmapSources[0];
   }catch(Exception up){
     throw up; // :P
   }
}
void  worker_DoWork(object sender, DoWorkEventArgs e)
{
   try{
     WorkerArgs thisArgs = (WorkerArgs)e.Argument as WorkerArgs;
     if (thisArgs != null){
        AutoResetEvent waitHandle = new AutoResetEvent(false);
        EventHandler scanCompleteHandler = (se, ev) => { waitHandle.Set(); };
        thisArgs._twain.ScanningComplete += scanCompleteHandler;
        thisArgs._twain.StartScanning(settings);
        waitHandle.WaitOne();
        if (thisArgs._twain.Images.Count &gt; 0)
        {
            foreach (var image in twain.Images)
            {
                BitmapSource bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(new Bitmap(image).GetHbitmap(),
                    IntPtr.Zero, Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
                thisArgs._bitmapSources.Add(bitmapSource);
            }
        }
    }
   }catch(Exception up){
     throw up; // :P
   }
}
