    //------- Parses binary ans.1 RSA private key; returns RSACryptoServiceProvider  ---
    public static RSACryptoServiceProvider DecodeRSAPrivateKey(byte[] privkey)
    {
            byte[] MODULUS, E, D, P, Q, DP, DQ, IQ ;
    
            // ---------  Set up stream to decode the asn.1 encoded RSA private key  ------
            MemoryStream  mem = new MemoryStream(privkey) ;
            BinaryReader binr = new BinaryReader(mem) ;    //wrap Memory Stream with BinaryReader for easy reading
            byte bt = 0;
            ushort twobytes = 0;
            int elems = 0;
            try {
                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                            binr.ReadByte();        //advance 1 byte
                    else if (twobytes == 0x8230)
                            binr.ReadInt16();       //advance 2 bytes
                    else
                            return null;
    
                    twobytes = binr.ReadUInt16();
                    if (twobytes != 0x0102) //version number
                            return null;
                    bt = binr.ReadByte();
                    if (bt !=0x00)
                            return null;
    
    
                    //------  all private key components are Integer sequences ----
                    elems = GetIntegerSize(binr);
                    MODULUS = binr.ReadBytes(elems);
    
                    elems = GetIntegerSize(binr);
                    E = binr.ReadBytes(elems) ;
    
                    elems = GetIntegerSize(binr);
                    D = binr.ReadBytes(elems) ;
    
                    elems = GetIntegerSize(binr);
                    P = binr.ReadBytes(elems) ;
    
                    elems = GetIntegerSize(binr);
                    Q = binr.ReadBytes(elems) ;
    
                    elems = GetIntegerSize(binr);
                    DP = binr.ReadBytes(elems) ;
    
                    elems = GetIntegerSize(binr);
                    DQ = binr.ReadBytes(elems) ;
    
                    elems = GetIntegerSize(binr);
                    IQ = binr.ReadBytes(elems) ;
    
                    Console.WriteLine("showing components ..");
                    if (verbose) {
                            showBytes("\nModulus", MODULUS) ;
                            showBytes("\nExponent", E);
                            showBytes("\nD", D);
                            showBytes("\nP", P);
                            showBytes("\nQ", Q);
                            showBytes("\nDP", DP);
                            showBytes("\nDQ", DQ);
                            showBytes("\nIQ", IQ);
                    }
    
                    // ------- create RSACryptoServiceProvider instance and initialize with public key -----
                    RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                    RSAParameters RSAparams = new RSAParameters();
                    RSAparams.Modulus =MODULUS;
                    RSAparams.Exponent = E;
                    RSAparams.D = D;
                    RSAparams.P = P;
                    RSAparams.Q = Q;
                    RSAparams.DP = DP;
                    RSAparams.DQ = DQ;
                    RSAparams.InverseQ = IQ;
                    RSA.ImportParameters(RSAparams);
                    return RSA;
            }
            catch (Exception) {
                    return null;
            }
            finally {
                    binr.Close();
            }
    }
