    private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
    {
        RacesMask raceMask = new RacesMask();
        Dictionary<string, string> rM = raceMask.GetRacesMask();
         int total = 0;
        foreach (var rMask in listBox1.SelectedItems)
        {
            total += int.Parse(rM[rMask.ToString()]);
        }
        MessageBox.Show(total.ToString());
