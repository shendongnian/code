    public void AppendRtf(RichtextBox rtb, string rtf)
    {
        rtb.Select(rtb.TextLength, 0);
        rtb.SelectedRtf = rtf;
    }
