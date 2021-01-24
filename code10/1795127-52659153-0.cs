    public GameObject obj;
    private void OnMouseDown()
    {
        if (Convert.ToInt32(dic["1st"]) == 1)
        {
            Instantiate(obj);
        }
    }
