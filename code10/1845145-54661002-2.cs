    private int theCount = 0;
    private int[] numbers = new int[20];
    
    private void btnEnter_Click(object sender, EventArgs e)
    {
        int num = 0;
    
        if (theCount < 20 && int.TryParse(txtBxStats.Text, out num))
        {
            numbers[theCount] = num;
            theCount++;                
        }
    
        lblNumCount.Text = $"{theCount} / 20";
    }
