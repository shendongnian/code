    // Cannot be static as we need a reference to `this`
    private Form2 _f2;
    public Form2 f2 {
        get {
            if (_f2 == null) {
                _f2 = new Form2(this);  // Pass form 1 as parameter to form 2.
            }
            return _f2;
        }
    }
    private void addButton1_Click(object sender, EventArgs e)
    {        
        f2.Show(); 
    }
