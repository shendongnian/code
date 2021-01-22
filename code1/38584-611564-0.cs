    double d = 0.00034101243963859839;
    string s = d.ToString("R");
    //...
    double d2 = double.Parse(s);
    if(d == d2)
    {
      //-- Success
    }
