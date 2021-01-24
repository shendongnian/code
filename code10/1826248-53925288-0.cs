        public void TimerLoop(int ms)
		{
			var now = DateTime.Now;	
			while(DateTime.Now < now.AddMilliseconds(ms))
			{	
			//do your stuff here
			}
		}
