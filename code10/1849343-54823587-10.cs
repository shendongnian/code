    foreach (string stringAnsers in StringAns)
    {
        if (stringAnsers.Equals(FindObjectOfType<GameController>().word))
        {
            Debug.Log("Button has been looked at");
            FindObjectOfType<GameController>().RandText();
        }
        else
        {
            Debug.Log("Button has been looked at");
            FindObjectOfType<GameController>().RandText();
            Score++;
        }
    }
                
