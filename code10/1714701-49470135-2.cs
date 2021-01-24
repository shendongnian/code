    private void form2_Load()
    {
    Mycodes()///call it if required
    }
    public void MyCodes() 
    {
      // Move codes from load event to here
    }
    // Now from Form1
    private void Bttn_Click()
    {
        Form2.MyCodes();
    }
