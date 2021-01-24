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
                  return string.Concat(imaginary.ToString(), "i");
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
                 return string.Concat(real.ToString(), " + i");
             }
             if (imaginary == -1)
             {
                 return string.Concat(real.ToString(), " - i");
             }
             if (imaginary < -1)
             {
                  imaginary = -imaginary;
                  return string.Concat(real.ToString(), " - ", imaginary.ToString(), "i");
              }
      }
      return string.Concat(real.ToString(), " + ", imaginary.ToString(), "i");
    }
