    public Color newColor;
    public GameObject objectToChangeColour;    
    void OnMouseUp()
    {
        Cursor.visible = true;
        if (dist < closeVPDist)
        {
            transform.SetParent(partnerGO.transform);
            StartCoroutine(InstallPart());
            isSnaped = true;
            objectToChangeColour.GetComponent<Renderer>().material.color = newColour; // Change the color of object to the newColour
        }
        if (dist > farVPDist)
        {
            //  transform.SetParent(null);
        }
    }
