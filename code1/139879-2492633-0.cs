    public void AttachInput(int input, int inIndex)
    {
        Inputs.Add(inIndex, input);
        InputCount++;
        IsResolved = false;
    }
