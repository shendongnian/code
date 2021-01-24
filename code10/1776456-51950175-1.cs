    int GetSum(Abc abc)
    {    
        int sum = 307; //23 + 68 + 96 + 57 + 63
        switch (abc) {
            case Abc.A:
                sum -= 23;
                break;
            case Abc.B:
                sum -= 68;
                break;
            // etc.
        }
        return sum;
    }
