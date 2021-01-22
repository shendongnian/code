    typedef struct {
       unsigned char exponent;  // 8 bites;
       unsigned long mantisaLo; // 32 of 39 bites
       unsigned char mantisaHi : 7, sign : 1;  // 7 of 39 bites
    } T_Real48;
    
    typedef struct {
       unsigned long mantisaLo; // 32 of 52 bites
       unsigned long mantisaHi:20, exponent: 11, sign : 1; // 20 of 52 bites
    } T_Double64;
    
    double doubleToReal48(double val)
    {
      T_Real48 real48;
      T_Double64 *double64 = (T_Double64*) &val;
    
      real48.mantisaHi = double64->mantisaHi >> 13;
      real48.mantisaLo =(double64->mantisaLo >> 13) + ((double64->mantisaHi & 0x1FFF) << 19);
      real48.exponent  = double64->exponent - 894;
      real48.sign      = double64->sign;
    
      if (real48.exponent == 0) {
          real48.mantisaHi = 0;
          real48.mantisaLo = 0;
      }
    
      return *(double *)&real48;
    }
    
    double real48ToDouble(double val)
    {
      T_Real48 *real48 = (T_Real48*) &val;
      T_Double64 double64;
    
      double64.mantisaHi = (real48->mantisaHi << 13) + (real48->mantisaLo >> 19);
      double64.mantisaLo = real48->mantisaLo << 13;
      double64.exponent  = real48->exponent + 894;
      double64.sign      = real48->sign;
    
      return *(double *)&double64;
    }
