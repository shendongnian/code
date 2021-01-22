    public bool LinelessEquals(string x, string y)
    {
        //deal with quickly handlable cases quickly.
        if(ReferenceEquals(x, y))//same instance
            return true;         // - generally happens often in real code,
                                 //and is a fast check, so always worth doing first.
        if(x == null)
            return y == null;
        if(y == null)
            return false;
        IEnumerator<char> eX = x.Where(c => c != '\n').GetEnumerator();
        IEnumerator<char> eY = y.Where(c => c != '\n').GetEnumerator();
        while(eX.MoveNext())
        {
            if(!eY.MoveNext()) //y is shorter
                return false;
            if(ex.Current != ey.Current)
                return false;
        }
        return !ey.MoveNext(); //check if y was longer.
    }
