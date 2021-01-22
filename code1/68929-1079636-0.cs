    public static void InvokeSafe<T>(this T c, Action<T> DoWhat)
	where T : System.Windows.Forms.Control
		{
			 
			Action d = delegate() { DoWhat(c); };
			if (c.InvokeRequired)
				c.Invoke(d);
			else
				DoWhat(c);
		}
