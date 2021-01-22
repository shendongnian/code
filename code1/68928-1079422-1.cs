    public static void Invoke<T>(this T c, Action<T> DoWhat)
        where T:System.Windows.Forms.Control
    {
        if (c.InvokeRequired)
            c.Invoke((EventHandler) delegate { DoWhat(c) } );
        else
            DoWhat(c);
    }
