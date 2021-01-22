        /// <summary>
        /// Convierte un numero Entero a Hexadecimal
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        public string MakeHex(int w)
        {
            try
            {
               char[] b =  {'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F'};
               char[] S = new char[7];
                  S[0] = b[(w >> 24) & 15];
                  S[1] = b[(w >> 20) & 15];
                  S[2] = b[(w >> 16) & 15];
                  S[3] = b[(w >> 12) & 15];
                  S[4] = b[(w >> 8) & 15];
                  S[5] = b[(w >> 4) & 15];
                  S[6] = b[w & 15];
                  string _MakeHex = new string(S, 0, S.Count());
                  return _MakeHex;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
   
