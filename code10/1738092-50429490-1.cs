    public static void ChangeState(bool b)
    {
        if(b == true)
        {
            yourPropertyWhcihIsBackState.isEnabled = true;
                Debug.WriteLine("Enabled Property");
        }else{
            yourPropertyWhcihIsBackState.isEnabled = false;
            Debug.WriteLine("Disabled Property");
        }
    }
