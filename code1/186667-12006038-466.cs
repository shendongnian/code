	public class ProgressBar
	{
		Util.ProgressBar prog;
		
		public ProgressBar() 
		{ 
			Init("Processing"); 
		}
		
		private void Init(string msg)
		{
			prog = new Util.ProgressBar (msg).Dump();
			prog.Percent=0;
		}
	
		public void Update(int percent)
		{
			Update(percent, null);
		}	
		
		public void Update(int percent, string msg)
		{
			prog.Percent=percent;
			if (String.IsNullOrEmpty(msg))
			{
				if (percent>99) prog.Caption="Done.";
			}
			else
			{
				prog.Caption=msg;
			}
		}
	}
