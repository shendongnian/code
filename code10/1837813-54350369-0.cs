    using System.Collections.Generic
    
    HashSet<int> RandomNumbersUsed = new HashSet<int>();
    
    public void RandomButton()
    {
        int randomNumber = Random.Range(1,3);
    
        if (!RandomNumbersUsed.Contains(randomNumber))
        {
            // Add it to the HashSet so that it cannot be used again
        }
        else
        {
            // Tell the user that the random has been selected before
        }
    
        if (randomNumber == 1)
        {
            // Do processing when random == 1
        }
    
        if (randomNumber == 2)
        {
            // Do processing when random == 2
        }
    
        // Continue adding necessary random numbers
    }
