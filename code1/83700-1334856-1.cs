	public class ....
		private void CountSize()
		{
			DirectoryInfo di = new DirectoryInfo(path);
			di.GetTotalSize()
		}
		private void ProgressCallback(float p)
		{
			progressBar.Value = (int)(p * (progressBar.Maximum - progressBar.Minimum)) + progressBar.Minimum;
		}
	}
	public static class IOExtensions
	{
		public static long GetTotalSize(this DirectoryInfo directory, 
			Action<float> progressCallback)
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
