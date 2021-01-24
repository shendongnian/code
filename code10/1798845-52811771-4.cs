    private void DestroyAndRespawn(GameObject obj)
    {
        StartCoroutine(DestroyAndRespawnRoutine(obj));
    }
    private IEnumerator DestroyAndRespawnRoutine(GameObject obj)
    {
        // first make a clone of the current Object
        var clone = Instantiate(obj, obj.transform.position, obj.transform.rotation, objtransform.parent);
        // disable the clone
        clone.SetActive(false);
        // Destroy the original
        Destroy(obj);
        // Wait 3 seconds
        yield return new WaitForSeconds(3f);
        // Set the clone active
        clone.SetActive(true);
    }
