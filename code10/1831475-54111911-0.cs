    // Make sure to put all your a objects in this list in the inspector
    public List<Transform> myABCObjects; 
    
    void CheckPositions()
    {
        // This foreach loop, will loop through your list of transforms, so your a b c 
        // objects would be added to this list via the inspector, or through whatver
        // code you are using to set them.
        foreach(Transform a in myABCObjects)
        {
            // Not to sure if you can do an == on a vector3, but I wouldn't want to
            // considering the data members are float, and can cause floating point error
            // Because of this I am getting the distance to the location, and using
            // Mathf.Approximately to check if the distance is close to 0f.
            if(Mathf.Approximately(car.position.distance(a.position), 0f))
            {
                car.taget.position = targetHere.position
                car.speed = 5;
                a1 = 0;
                Destroy(obj, 5)
            }
        }
    }
