    String src = " 8 2 /  5";
    String Regex = @"([1-9])([0-9]*)([ ])([1-9])([0-9]*)((.)([0-9]+)|)([ ])([- / + *]){1}([ ])([1-9])([0-9]*)((.)([0-9]+)|)";
    if(!Regex.IsMatch(src , Regex ))
       return;
    
    
    float Base = float.Parse(Base.Split(" ")[0], CultureInfo.InvariantCulture.NumberFormat);
    float Devided= float.Parse(Base.Split(" ")[1], CultureInfo.InvariantCulture.NumberFormat);
    float Operator= float.Parse(Base.Split(" ")[2], CultureInfo.InvariantCulture.NumberFormat);
    float Denominator= float.Parse(Base.Split(" ")[3], CultureInfo.InvariantCulture.NumberFormat);
    //TODO your operation here
