                byte[] rsaExp = rsaParameters.Exponent.ToByteArray();
                byte[] Modulus = rsaParameters.Modulus.ToByteArray();
                // Microsoft RSAParameters modulo wants leading zero's removed so create new array with leading zero's removed
                int Pos = 0;
                for (int i = 0; i < Modulus.Length; i++)
                {
                    if (Modulus[i] == 0)
                    {
                        Pos++;
                    }
                    else
                    {
                        break;
                    }
                }
                byte[] rsaMod = new byte[Modulus.Length - Pos];
                Array.Copy(Modulus, Pos, rsaMod, 0, Modulus.Length - Pos);
