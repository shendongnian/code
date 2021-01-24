    if (Fiok[i,j]==0)
    {
          int[,] kisorolt = sor.Dequeue();
          for (int k = 0; k < kisorolt.GetLength(0); k++)
          {
              for (int l = 0; l < kisorolt.GetLength(1); l++)
              {
                  Fiok[i, j] = kisorolt[k, l];
              }
           }
    }
    else
    {
       //put any else statement
    }
