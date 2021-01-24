    for (int i = Count; i <= words1.Length; i++)
    {
        if (i == words1.Length)
        {
            for (int bb = Count3; bb < words2.Length; bb++)
            {
                sw.Write($" {words2[bb]}");
            }
            sw.Write(" >>> End of file 2 >>> ");  // You've parsed through all words2
            sw.Write(" >>> End of file 1 >>> ");  // since `i=Length` you've parsed 
                                                  //through all words1 now too
            break;  
        }
        if (words1[i] == words2[Count]) // Statement that crashes.
        {
             <Lots of code>
        }      
        else
        {
            sw.Write($"{words1[i]} ");
            c = false;
        }
    }
