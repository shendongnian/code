    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject obj = eventData.pointerCurrentRaycast.gameObject;
        Text text = obj.GetComponent<Text>();
    
        if (text != null)
        {
            if (text.text == "EnteringText1")
            {
                text.text = "i m entering text1";
                text.transform.position = new Vector3(100f, 100f, 0f);
            }
    
            else if (text.text == "EnteringText2")
            {
                text.text = "i m entering text2";
                text.transform.position = new Vector3(100f, 100f, 0f);
            }
        }
    }
