    public String CleanStringToLettersNumbers(String data)
    {
        var result = String.Empty;
        foreach (var item in data)
        {
            var c = '_';
            if ((int)item >= 97 && (int)item <= 122 ||
                (int)item >= 65 && (int)item <= 90 ||
                (int)item >= 48 && (int)item <= 57 ||
                (int)item == 32)
            {
                c = item;
            }
            result = result + c;
        }
        return result;
    }
