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
                // Your logic here if location is the same...
                // so if you are trying to remove say a1
                // add this object to a list, to be removed after the loop
                // then continue on.
            }
        }
        // if you are removing an object, check the list size, then loop through it to remove the objects from your original list...
    }
