	class A
	{	
		public void Button_Click(object sender, RoutedEventArgs e)
		{
			B senders = new B();
			C c = new C();
			c.Connect(senders);
			senders.OnPageSwap(new StartEventArgs());
		}
	}
	
	public delegate void StartEventHandler(object sender, StartEventArgs e);
	public class B
	{
		public event StartEventHandler PageSwap;
		public virtual void OnPageSwap(StartEventArgs e)
		{
			Console.WriteLine("Entered PageSwapSender");
			if (PageSwap != null) PageSwap(this, e);
		}
	}
	
	class C
	{
		public void Connect(B sender)
		{
			sender.PageSwap += new StartEventHandler(this.sender_PageSwap);
			Console.WriteLine("Entered Connect");
		}
	
		private void sender_PageSwap(object sender, StartEventArgs e)
		{
			Console.WriteLine("Entered Handler");
		}
	}
