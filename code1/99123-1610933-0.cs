    public int getOctet( int which )
    {
        if ( which >= 0 && which <= 3 )
            return this.Octet[ which ];
        else
            return -1;  // error. Consider throwing an exception
    }
