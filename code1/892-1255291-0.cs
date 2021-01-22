static class Program {
	public static MouseUpDownFilter mudFilter = new MouseUpDownfilter();
	public static void Main() {
		Application2.AddMessageFilter(mudFilter);
		Application2.Run(new MainForm());
	}
}
