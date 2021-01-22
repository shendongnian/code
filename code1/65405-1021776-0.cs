    DateTime otherDate = DateTime.Now;
    int compResult = dt.CompareTo(otherDate);
    if(compResult > 0) { Console.Write("dt is after otherDate"); }
    else if(compResult < 0) { Console.Write("dt is before otherDate"); }
    else { Console.Write("dt is equal to otherDate"); }
