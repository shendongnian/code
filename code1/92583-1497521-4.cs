    private int unit;
    public event EventHandler UnitChanged; // or via the "Events" list
    public int Unit {
        get {return unit;}
        set {
            if(value!=unit) {
                unit = value;
                EventHandler handler = UnitChanged;
                if(handler!=null) handler(this,EventArgs.Empty);
            }
        }
    }
