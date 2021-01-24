    private bool _isBlack = false;
    private bool _isWhite = true;
    public IEnumerable<string> GetValues()
    {
       if(_isBlack)
       {
           yield return "black";
       }
       if(_isWhite)
       {
           yield return "white";
       }
    }
