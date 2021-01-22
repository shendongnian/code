    ...
    else if (topObject.Indent == oo.Indent) 
    { 
      stack.Pop(); 
      stack.Push(oo); 
    } 
    else 
    { 
      while (stack.Top().Indent >= oo.Indent) 
        stack.Pop(); 
      stack.Push(oo); 
    }
