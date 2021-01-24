    void Update()
    {
        if (transform.position.y < generationPoint.position.y)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            gearSelector = Random.Range(0, theGears.Length);
            widthChange = transform.position.x + Random.Range(-maxWidthChange, maxWidthChange); // FIX: the first argument of Random.Range must be the lower limit, the second one that upper limit
            if (widthChange > maxWidth)
            {
                widthChange = maxWidth;
            }
            else if (widthChange < minWidth)
            {
                widthChange = minWidth;
            }
            Vector3 newPosition = new Vector3(widthChange, transform.position.y + distanceBetween, transform.position.z); // FIX: instead of overwriting the spawner's position, store the newPosition in a local and use that
            Instantiate(theGears[gearSelector], newPosition, transform.rotation);
        }
    }
