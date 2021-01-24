    public void CreateTextButtonClick(string text)
    {
        Debug.Log("Hey starting of this..");
        //Create Canvas Text and make it child of the Canvas
        GameObject txtObj = new GameObject("myText");
        txtObj.AddComponent<RectTransform>();
        txtObj.transform.SetParent(this.transform, false);
    
        GameObject pan = new GameObject("text");
        pan.transform.SetParent(txtObj.transform, false);
    
        //Attach Text,RectTransform, an put Font to it
        Text txt = pan.AddComponent<Text>();
        txt.text = text;
        Font arialFont = Resources.GetBuiltinResource<Font>("Arial.ttf");
        txt.font = arialFont;
        txt.lineSpacing = 1;
        txt.color = Color.blue;
    }
