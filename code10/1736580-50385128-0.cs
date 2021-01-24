    RaycastHit hit;
    Ray spawnRay = ARCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
    LayerMask selectLayers = 1 << LayerMask.NameToLayer(DetectedPlanesLayer);
    if (spawnedObject == null && Physics.Raycast(spawnRay, out hit, Mathf.Infinity, spawnLayers))
    {
        spawnedObject = Instantiate(objectPrefab, hit.point, Quaternion.identity);
    }
