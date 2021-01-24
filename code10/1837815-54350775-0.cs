    public void RandomButton()
    {
        Randomizer = Random.Range(1, 3);
        if (Randomizer == 1)
        {
            if (Random1 == 1)
            {
                Debug.Log("Nested   Value");
            }
            else
            {
                Debug.Log("First Value");
                Random1 = 1;
            }
        }
        
        // Repeat the same pattern for the other number here...
    }
