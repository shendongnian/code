    Control c = new Control();
    TextBox t = new TextBox();
    IControl ic = c;
    IControl it = t;
    c.Paint();			// invokes Control.Paint();
    t.Paint();			// invokes TextBox.Paint();
    ic.Paint();			// invokes Control.Paint();
    it.Paint();			// invokes Control.Paint();
