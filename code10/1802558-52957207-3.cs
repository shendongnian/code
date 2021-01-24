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
        Num++;
        SanatizeNum();
        ToggleRenderer(Num);
    }
    private void GoToLast()
    {
        Num--;
        SanatizeNum();
        ToggleRenderer(Num);
    }
    private void ToggleRenderer(int index)
    {
        var renderer = renderers[Textmeshes [index]];
        renderer.enabled = !renderer.enabled;
    }
    private void SanatizeNum()
    {
        Num = Mathf.Clamp(Num, 0, TextMeshs.Count);
    }
