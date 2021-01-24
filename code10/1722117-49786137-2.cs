    private void btnSplit_Click(object sender, EventArgs e)
    {
        string blah = tbInput.Text;
        tbInput.Clear();
        var lst = blah.ToUpper().Split('E').ToList();
        foreach (var item in lst)
            if (item.Trim().StartsWith("S"))
                rt1.AppendText($"Steps: {item.Remove(0, 1)} \n");
            else if (item.Trim().StartsWith("T"))
                rt2.AppendText($"Temperature: {item.Remove(0, 1)} \n");
            else if (item.Trim().StartsWith("P"))
                rt3.AppendText($"Pulse: {item.Remove(0, 1)} \n");
    }
