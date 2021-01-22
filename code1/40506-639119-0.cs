    public int CountControls(Control top)
    {
        int cnt = 1;
        foreach (Control c in top.Controls)
            cnt += CountControls(c);
        return cnt;
    }
