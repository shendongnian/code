	public class Form1 : Form
    {
        private Action<float> updateProgMethod;
        
        private void Form1_Load()
        {
            updateProgMethod = UpdateProgress;
        }
    
		private void CountSize()
		{
			DirectoryInfo di = new DirectoryInfo(path);
			di.GetTotalSize(ProgressCallback)
		}
        // Takes callbacks from the GetTotalSize() method
		private void ProgressCallback(float p)
		{
            // Invokes update progress bar on GUI thread:
			this.BeginInvoke(updateProgMethod, new object[] { p });
		}
        
        // Actually updates the progress bar:
        private void UpdateProgress(float p)
        {
            progressBar.Value = (int)(p * (progressBar.Maximum - progressBar.Minimum)) + progressBar.Minimum;
        }
	}
	public static class IOExtensions
	{
		public static long GetTotalSize(this DirectoryInfo directory, Action<float> progressCallback)
		{
			FileInfo[] files = di.GetFiles("*.*", SearchOption.AllDirectories);
			long sum = 0;
			for (int i = 0; i < files.Length; i++)
			{
				sum += files[i].Length;
				progressCallback((float)i / files.Length);
			}
			return sum;
		}
	}
