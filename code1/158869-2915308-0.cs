    public string[] myList
    {
        get
        {
            return _myList;
        }
        
        set 
        {
            _myList = value; // you have to assign it manually
            for (int i = 0; i < _myList.Length; i++)
            {
                if (_myList[i] != null) _myList[i] = _myList[i].Trim();
            }
        }
    }
