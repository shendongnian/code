    public static void Main()
    {
        input = GetComponent<VRInput>();
        // Overlap the event
        var o = new OverlapEvents { Source = input };
        // You can now call the event! (Note how Target should be null but is of type VRInput)
        o.Target.SimulateClick();
    }
