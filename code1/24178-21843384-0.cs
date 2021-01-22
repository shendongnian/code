    keys = new Keys[38];
    Keys[] tempkeys;
    tempkeys = Enum.GetValues(typeof(Keys)).Cast<Keys>().ToArray<Keys>();
    int j = 0;
    for (int i = 0; i < tempkeys.Length; i++)
    {
        if (i == 1 || i == 11 || (i > 26 && i < 63))//get the keys listed above as well as A-Z
        {
            keys[j] = tempkeys[i];//fill our key array
            j++;
        }
    }
    IskeyUp = new bool[keys.Length]; //boolean for each key to make the user have to release the key before adding to the string
    for (int i = 0; i < keys.Length; i++)
        IskeyUp[i] = true;
