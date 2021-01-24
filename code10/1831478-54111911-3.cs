    // Make sure to put all your a objects in this list in the inspector
    public List<Transform> myABCObjects; 
    
    void CheckPositions()
    {
        // This for loop, will loop through indices 0 - myABCObjects.count - 1, so your a b c 
        // objects would be added to this list via the inspector, or through whatver
        // code you are using to set them.
        for(int i = 0; i < myABCObjects.count; ++i)
        {
            // Not to sure if you can do an == on a vector3, but I wouldn't want to
            // considering the data members are float, and can cause floating point error
            // Because of this I am getting the distance to the location, and using
            // Mathf.Approximately to check if the distance is close to 0f.
            if(Mathf.Approximately(car.position.distance(myABCObjects[i].position), 0f))
            {
                 // Your logic here if location is the same...
            }
        }
    }
