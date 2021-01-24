    double score = 0;
    Dictionary<char, double> Letters3 = new  Dictionary<char, double>();
    foreach(var c2 in Letters)
    {
        if (o == c2.Key)
        {
            switch(countofoccur)
            {
                case 1:
                    score = c2.Value;
                    Letters3.Add(o, score);
                    break;
                case 2:
                    score = c2.Value+ (0.5 * c2.Value);
                    Letters3.Add(o, score);
                    break;
                case 3:
                    score = c2.Value + (0.5 * c2.Value) +2*c2.Value;
                    Letters3.Add(o, score);
                    break;
                default :  
                break;  
            }
        }
    }
