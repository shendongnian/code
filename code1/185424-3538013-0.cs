    string csv = 543472,"36743721","Rutois, a.s.","151","some name","01341",55,"112",1 ;
    string[] values;
    values = csv.Split(",");
    for(int i = 0; i<values.Length; i++)
    {
        values[i] = values[i].Replace("\"", "");
    }
