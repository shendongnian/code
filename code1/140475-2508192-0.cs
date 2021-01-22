 public partial class ProgressWindow : Window
   {
      public ProgressWindow(string title, string supertext, string subtext)
      {
         InitializeComponent();
         EmptyDelegate = RaiseOnDispatcher;
        this.Title = title; 
        this.SuperText.Text = supertext; 
        this.SubText.Text = subtext; 
      }
       
 
    internal void UpdateProgress(int count, int total) 
    {
       this.Dispatcher.Invoke(EmptyDelegate,DispatcherPriority.Render,new object[]{count,total}); 
    }
    private static Action<int, int> EmptyDelegate = null;
    private void RaiseOnDispatcher(int count, int total)
    {
       this.ProgressBar.Maximum = Convert.ToDouble(total);
       this.ProgressBar.Value = Convert.ToDouble(count);
       this.SubText.Text = String.Format("{0} of {1} finished", count, total);
    }
   }
   public class Gallery
   {
      static Action<int, int> ActionDelegate=null;
      public static void ImportFolder(string folderPath, Action<int, int> progressUpdate)
      {
         ActionDelegate = progressUpdate;
         BackgroundWorker backgroundWorker = new BackgroundWorker();
         backgroundWorker.DoWork += new DoWorkEventHandler(worker_DoWork);
         backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_WorkCompleted);
         backgroundWorker.RunWorkerAsync(folderPath);
         backgroundWorker = null;
      }
     static void worker_DoWork(object sender, DoWorkEventArgs e)
      {
         string folderPath = e.Argument.ToString();
         DirectoryInfo dir = new DirectoryInfo(folderPath);
         FileInfo[] files = dir.GetFiles();
         for (int i = 0; i < files.Length; i++)
         {
            // do stuff with the file 
            Thread.Sleep(1000);// remove in actual implementation
            if (null != ActionDelegate)
            {
               ActionDelegate.Invoke(i + 1, files.Length);
            }
         }
      }
      static void worker_WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         //do after work complete
      }
      public static void Operate()
      {
         string folder = "folderpath";
         ProgressWindow progress = new ProgressWindow("Import Folder Progress", String.Format("Importing {0}", folder), String.Empty);
         progress.Show();
         Gallery.ImportFolder(folder, ((c, t) => progress.UpdateProgress(c, t)));
         progress.Close();
      }
   }
