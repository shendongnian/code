    [GLib.ConnectBefore]
    public virtual void AddButtonPressed(object sender, EventArgs e)     {
        Console.WriteLine("Button pressed");
        for (uint i = 0; i < plus.Length; i++) {
    	    if (sender.Equals(plus[i])) {
    		uint index = i;
    		i = (uint)plus.Length;
    		Console.WriteLine(index);
    	    }
    	}
    }
