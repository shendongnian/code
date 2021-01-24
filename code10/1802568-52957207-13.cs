    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            GoToNext();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            GoToLast();
        }
    }
    private void GoToNext()
    {
        // Hide the current renderer
        SetRendererEnabled(Num, false);
        Num++;
        SanatizeNum();
        // Show the new renderer
        SetRendererEnabled(Num, true);
    }
    private void GoToLast()
    {
        SetRendererEnabled(Num, false);
        Num--;
        SanatizeNum();
        SetRendererEnabled(Num, true);
    }
    private void SanatizeNum()
    {
        Num = Mathf.Clamp(Num, 0, Textmeshes.Count -1);
    }
    private void SetRendererEnabled(int index, bool enabled)
    {
        renderers[Textmeshes[index]].enabled = enabled;
    }
