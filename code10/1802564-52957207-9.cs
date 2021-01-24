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
        renderers[textMesh[Num]].enabled = false;
        Num++;
        SanatizeNum();
        // Show the new renderer
        renderers[Textmeshes[Num]].enabled = true;
    }
    private void GoToLast()
    {
        renderers[textMesh[Num]].enabled = false;
        Num--;
        SanatizeNum();
        renderers[Textmeshes[Num]].enabled = true;
    }
    private void SanatizeNum()
    {
        Num = Mathf.Clamp(Num, 0, TextMeshs.Count);
    }
