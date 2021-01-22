    protected bool IsVisible()
    {
        bool result= true;
    
        if(EditUserName == string.empty)
        {
            result= false;
        }
        return result;
    }
