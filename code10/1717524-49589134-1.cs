    public override string ToString()
    {
         if (real == 0)
         {
              if (imaginary == 0)
              {
                  return "0";
              }
              if (imaginary == 1)
              {
                  return "i";
              }
              if (imaginary == -1)
              {
                  return "-i";
              }
              if (imaginary != 1)
              {
                  return $"{imaginary}i";
              }
             }
        else
        {
             if (imaginary == 0)
             {
                 return real.ToString();
             }
             if (imaginary == 1)
             {
                 return $"{real} + i";
             }
             if (imaginary == -1)
             {
                 return $"{real} - i";
             }
             if (imaginary < -1)
             {
                  imaginary = -imaginary;
                  return $"{real} - {imaginary}i"; 
              }
      }
      return $"{real} + {imaginary}i";
    }
