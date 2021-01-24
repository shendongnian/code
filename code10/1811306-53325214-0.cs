        public async void CheckedChanged(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine($"Calling CheckedChanged {s.Name}: {s.CheckState}");
        await Filter(nameof("CheckedChanged"));
    }
    
    public async Task Filter(string caller = "undefined")
    {
        System.Diagnostics.Debug.WriteLine($"Calling Filter from {caller}");
        // ....
    }
