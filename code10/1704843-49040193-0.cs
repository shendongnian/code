    private void btn_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        var hiddenBtn = flowLayoutPanel1.controls[btn.Tag + 1];
        hiddenBtn.Visible = true;
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < 3; i++) 
        {
           createContractButton(i);  
           createInfoButton();  
        }
    }
  
    private void createContractButton(int i)
    {
        Button contractButton = contractButtonCreation("contractButton");
        contractButton.Tag = i
        flowLayoutPanel1.Controls.Add(contractButton);
        contractButton.Click += new EventHandler(btn_Click);
     }
