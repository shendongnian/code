    private void button1_Click(object sender, EventArgs e)
    {
        int nGCD = GetGreatestCommonDivisor(Screen.PrimaryScreen.Bounds.Height, Screen.PrimaryScreen.Bounds.Width);
        string str = string.Format("{0}:{1}", Screen.PrimaryScreen.Bounds.Height / nGCD, Screen.PrimaryScreen.Bounds.Width / nGCD);
        MessageBox.Show(str);
    }
    
    static int GetGreatestCommonDivisor(int a, int b)
    {
        return b == 0 ? a : GetGreatestCommonDivisor(b, a % b);
    }
