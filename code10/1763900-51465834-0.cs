    public Text text1;
    public Text text2;
    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject obj = eventData.pointerCurrentRaycast.gameObject;
    
        if (obj.name == "text1")
        {
            text1.text = "i m entering text1";
            text1.transform.position = new Vector3(100f, 100f, 0f);
        }
    
        else if (obj.name == "text2")
        {
            text2.text = "i m entering text2";
            text2.transform.position = new Vector3(100f, 100f, 0f);
    
        }
    }
