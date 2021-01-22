    private void SetProgressBar(string text, int position, int max)
    {
        if(max == 0)
            return;
        int percent = (100 * position) / max; //when max is 0 bug hits
        string txt = text + String.Format(". {0}%", percent);
        SetStatus(txt);
    }
