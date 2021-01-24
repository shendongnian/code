    bool hideOneTime = false;
    
    ...
    if (!hideOneTime)
    {
        if (score < 2000)
        {
            Rock1.gameObject.SetActive (true);
        }
        else if (score > 2000)
        {
            Rock1.gameObject.SetActive (false);
            hideOneTime = true;            
        }
    }
