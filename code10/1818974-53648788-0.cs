    bool is Destroyed = false; //Define this on top of the script
    public IEnumerator cookandburn(string rawFoodName) {
    float x = Random.Range(MinX, MaxX);
    float y = Random.Range(MinY, MaxY);
    yield return new WaitForSeconds(cooktime);
    if (rawFoodName == "blobraw1")
    {
        // generate raw food
        Instantiate(cooked1, new Vector3(x, y, 10), Quaternion.identity);
        yield return new WaitForSeconds(burntime);
        // generate burned food if condition doesn't satisfy
        // Check that if the object was destroyed
        if(!isDestroyed){
            Instantiate(burned1, new Vector3(x, y, 10), Quaternion.identity);
        }
    }
    isDestroyed = false;
    }
