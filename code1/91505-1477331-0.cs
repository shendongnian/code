    int[] dbNavnX = new int[8]; 
    int[] verdierX = new int[8];
    string[] boxList = new string[8];
    private void Form1_Load(object sender, EventArgs e)
    {
        for (var i = 0; i < 8; i++)
        {
            TextBox tb = FindControl("box" + i.ToString());
            boxList[i] = tb.Text;
        }
    }
    private void sumX()
    {
        for (int sum = 0; sum < 8; sum++)
        {
            verdierX[sum] = (int)decimal.Parse(boxList[sum]);
        }
    }
