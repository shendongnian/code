	class B
	{
		public event EventHandler LogGenerated = delegate { };
		void test()
		{
			LogGenerated("Some log text", EventArgs.Empty);
		}
	}
	class A : Control
	{
		public A()
		{
			B b = new B();
			b.LogGenerated += new EventHandler(b_LogGenerated);
		}
		void b_LogGenerated(object sender, EventArgs e)
		{
			this.SafeInvoke(() => { textBox1.Text += (String)sender; });
		}
	}
