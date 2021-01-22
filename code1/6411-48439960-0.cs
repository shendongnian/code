    //somewhere in your code
    static long _bob = "Bob".GetUniqueHashCode();
    static long _jill = "Jill".GetUniqueHashCode();
    static long _marko = "Marko".GeUniquetHashCode();
    void MyMethod()
    {
       ...
       if(childNode.Tag==0)
          childNode.Tag= childNode.Name.GetUniquetHashCode()
       switch(childNode.Tag)
       {
           case _bob :
            break;
           case _jill :
             break;
           case _marko :
            break;
       }
    }
