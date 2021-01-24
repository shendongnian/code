    public GameObject [] dress;
    private int _index;
    public void PreviousModel()
    {
        // Hide current model
        dress[index].SetActive(false);
        _index--;
        if(index < 0)
        {
            index = dress.Length -1;
        }
        // Show previous model
        dress[index].SetActive(true);
    }
    public void NextModel()
    {
        // Hide current model
        dress[index].SetActive(false);
        _index++;
        if(index > dress.Length -1)
        {
            index = 0;
        }
         
        // Show next model
        dress[index].SetActive(true);
    }
