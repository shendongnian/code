    Public Static int GetOrder(string _arg)
    {
        switch (_arg)
        {
            case 'Section One':
                return 1;
            case 'Section Two':
                return 2;
            case 'Section Three':
                return 3;
                .
                .
                .
            default:
                return int.MaxValue;
        }
    }
