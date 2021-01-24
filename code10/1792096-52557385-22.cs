    bool a = A();
    bool c;
    if (a == false) // interesting operation
      c = a;
    else
    {
      bool b = B(); 
      c = a & b;    // interesting operation
    }
    bool r = c;
