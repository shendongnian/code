    ...
    
    public string textToShow = "Floating text you want to show";
    public Vector3 pointOfCollision = gameObject.transform.position; // set on impact
    
    void OnDestroy()
    {
        GameObject floatingText = Instantiate(floatingTextPrefab, pointOfCollision, floatingTextPrefab.transform.localRotation);
        floatingText.Text.text = textToShow;
        StartCoroutine(floatingText.GetComponent<Float>().Fade());
    }
