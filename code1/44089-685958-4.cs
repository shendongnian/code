    for(int i = 0; i < 100; i++)
    { 
      start:
    
      for(int i = 0; i < 10; i++)
      {
         if(magicValue1)
           goto end;
        if(magicValue2)
           goto start;
      }
    }
    end : 
