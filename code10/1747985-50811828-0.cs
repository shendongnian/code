    public void execAction(int inVar, Action<int> action)
    {
        int yourParameterToPass = 42; // you need to figure out how to get this
        action(yourParameterToPass);
        // or: action.Invoke(yourParameterToPass);
    }
