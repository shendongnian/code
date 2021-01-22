    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    
    using System.IO;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Engines;
    using Org.BouncyCastle.Crypto.Generators;
    using Org.BouncyCastle.Crypto.Modes;
    using Org.BouncyCastle.Crypto.Paddings;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.Security;
    using Org.BouncyCastle.Utilities.Encoders;
    
    namespace BouncyCastleProject
    {
        public class DesExample
        {
            // Encrypting or decrypting ?
            private bool encrypt = true;
    
            // To hold the initialised DESede cipher
            private PaddedBufferedBlockCipher cipher = null;
    
            // The input stream of bytes to be processed for encryption
            private Stream inStr = null;
    
            // The output stream of bytes to be procssed
            private Stream outStr = null;
    
            // The key
            private byte[] key = null;
    
            /*
            * start the application
            */
            //////public static void Main(string[] args)
            //////{
            //////    bool encrypt = true;
            //////    string infile = null;
            //////    string outfile = null;
            //////    string keyfile = null;
    
            //////    if (args.Length < 2)
            //////    {
            //////        //    Console.Error.WriteLine("Usage: java " + typeof(DesExample).Name + " infile outfile [keyfile]");
            //////        Console.Error.WriteLine("Usage: " + typeof(DesExample).Name + " infile outfile [keyfile]");
            //////        Environment.Exit(1);
            //////    }
    
            //////    keyfile = "deskey.dat";
            //////    infile = args[0];
            //////    outfile = args[1];
    
            //////    if (args.Length > 2)
            //////    {
            //////        encrypt = false;
            //////        keyfile = args[2];
            //////    }
    
            //////    DesExample de = new DesExample(infile, outfile, keyfile, encrypt);
            //////    de.process();
            //////}
    
            // Default constructor, used for the usage message
            public DesExample()
            {
            }
    
            /*
            * Constructor, that takes the arguments appropriate for
            * processing the command line directives.
            */
            public DesExample(
                string infile,
                string outfile,
                string keyfile,
                bool encrypt)
            {
                /* 
                * First, determine that infile & keyfile exist as appropriate.
                *
                * This will also create the BufferedInputStream as required
                * for reading the input file.  All input files are treated
                * as if they are binary, even if they contain text, it's the
                * bytes that are encrypted.
                */
                this.encrypt = encrypt;
                try
                {
                    inStr = File.OpenRead(infile);
                }
                catch (FileNotFoundException)
                {
                    //Console.Error.WriteLine("Input file not found [" + infile + "]");
                    Environment.Exit(1);
                }
    
                try
                {
                    outStr = File.Create(outfile);
                }
                catch (IOException)
                {
                    //Console.Error.WriteLine("Output file not created [" + outfile + "]");
                    Environment.Exit(1);
                }
    
                if (encrypt)
                {
                    try
                    {
                        /*
                        * The process of creating a new key requires a 
                        * number of steps.
                        *
                        * First, create the parameters for the key generator
                        * which are a secure random number generator, and
                        * the length of the key (in bits).
                        */
                        SecureRandom sr = new SecureRandom();
    
                        KeyGenerationParameters kgp = new KeyGenerationParameters(
                            sr, 
                            DesEdeParameters.DesEdeKeyLength * 8);
    
                        /*
                        * Second, initialise the key generator with the parameters
                        */
                        
                        DesEdeKeyGenerator kg = new DesEdeKeyGenerator();
                        kg.Init(kgp);
    
                        /*
                        * Third, and finally, generate the key
                        */
                        key = kg.GenerateKey();
    
                        /*
                        * We can now output the key to the file, but first
                        * hex Encode the key so that we can have a look
                        * at it with a text editor if we so desire
                        */
                        Stream keystream = File.Create(keyfile);
                        byte[] keyhex = Hex.Encode(key);
                        keystream.Write(keyhex, 0, keyhex.Length);
                        keystream.Flush();
                        keystream.Close();
                    }
                    catch (IOException)
                    {
                        //Console.Error.WriteLine("Could not decryption create key file [" + keyfile + "]");
                        Environment.Exit(1);
                    }
                }
                else
                {
                    try
                    {
                        // TODO This block is a bit dodgy
    
                        // read the key, and Decode from hex encoding
                        Stream keystream = File.OpenRead(keyfile);
                        //     int len = keystream.available();
                        int len = (int)keystream.Length;
                        byte[] keyhex = new byte[len];
                        keystream.Read(keyhex, 0, len);
                        key = Hex.Decode(keyhex);
                    }
                    catch (IOException)
                    {
                        //Console.Error.WriteLine("Decryption key file not found, or not valid [" + keyfile + "]");
                        Environment.Exit(1);
                    }
                }
            }
    
            public void process()
            {
                /* 
                * Setup the DESede cipher engine, create a PaddedBufferedBlockCipher
                * in CBC mode.
                */
                cipher = new PaddedBufferedBlockCipher(
                    new CbcBlockCipher(new DesEdeEngine()));
    
                /*
                * The input and output streams are currently set up
                * appropriately, and the key bytes are ready to be
                * used.
                *
                */
    
                if (encrypt)
                {
                    performEncrypt(key);
                }
                else
                {
                    performDecrypt(key);
                }
    
                // after processing clean up the files
                try
                {
                    inStr.Close();
                    outStr.Flush();
                    outStr.Close();
                }
                catch (IOException)
                {
                }
            }
    
            /*
            * This method performs all the encryption and writes
            * the cipher text to the buffered output stream created
            * previously.
            */
            private void performEncrypt(byte[] key)
            {
                // initialise the cipher with the key bytes, for encryption
                cipher.Init(true, new KeyParameter(key));
    
                /*
                * Create some temporary byte arrays for use in
                * encryption, make them a reasonable size so that
                * we don't spend forever reading small chunks from
                * a file.
                *
                * There is no particular reason for using getBlockSize()
                * to determine the size of the input chunk.  It just
                * was a convenient number for the example.  
                */
                // int inBlockSize = cipher.getBlockSize() * 5;
                int inBlockSize = 47;
                int outBlockSize = cipher.GetOutputSize(inBlockSize);
    
                byte[] inblock = new byte[inBlockSize];
                byte[] outblock = new byte[outBlockSize];
    
                /* 
                * now, read the file, and output the chunks
                */
                try
                {
                    int inL;
                    int outL;
                    byte[] rv = null;
                    while ((inL = inStr.Read(inblock, 0, inBlockSize)) > 0)
                    {
                        outL = cipher.ProcessBytes(inblock, 0, inL, outblock, 0);
    
                        /*
                        * Before we write anything out, we need to make sure
                        * that we've got something to write out. 
                        */
                        if (outL > 0)
                        {
                            rv = Hex.Encode(outblock, 0, outL);
                            outStr.Write(rv, 0, rv.Length);
                            outStr.WriteByte((byte)'\n');
                        }
                    }
    
                    try
                    {
                        /*
                        * Now, process the bytes that are still buffered
                        * within the cipher.
                        */
                        outL = cipher.DoFinal(outblock, 0);
                        if (outL > 0)
                        {
                            rv = Hex.Encode(outblock, 0, outL);
                            outStr.Write(rv, 0, rv.Length);
                            outStr.WriteByte((byte)'\n');
                        }
                    }
                    catch (CryptoException)
                    {
    
                    }
                }
                catch (IOException ioeread)
                {
                   // Console.Error.WriteLine(ioeread.StackTrace);
                }
            }
    
            /*
            * This method performs all the decryption and writes
            * the plain text to the buffered output stream created
            * previously.
            */
            private void performDecrypt(byte[] key)
            {
                // initialise the cipher for decryption
                cipher.Init(false, new KeyParameter(key));
    
                /* 
                * As the decryption is from our preformatted file,
                * and we know that it's a hex encoded format, then
                * we wrap the InputStream with a BufferedReader
                * so that we can read it easily.
                */
                //   BufferedReader br = new BufferedReader(new StreamReader(inStr));
                StreamReader br = new StreamReader(inStr); // 'inStr' already buffered
    
                /* 
                * now, read the file, and output the chunks
                */
                try
                {
                    int outL;
                    byte[] inblock = null;
                    byte[] outblock = null;
                    string rv = null;
                    while ((rv = br.ReadLine()) != null)
                    {
                        inblock = Hex.Decode(rv);
                        outblock = new byte[cipher.GetOutputSize(inblock.Length)];
    
                        outL = cipher.ProcessBytes(inblock, 0, inblock.Length, outblock, 0);
                        /*
                        * Before we write anything out, we need to make sure
                        * that we've got something to write out. 
                        */
                        if (outL > 0)
                        {
                            outStr.Write(outblock, 0, outL);
                        }
                    }
    
                    try
                    {
                        /*
                        * Now, process the bytes that are still buffered
                        * within the cipher.
                        */
                        outL = cipher.DoFinal(outblock, 0);
                        if (outL > 0)
                        {
                            outStr.Write(outblock, 0, outL);
                        }
                    }
                    catch (CryptoException)
                    {
    
                    }
                }
                catch (IOException ioeread)
                {
                    //Console.Error.WriteLine(ioeread.StackTrace);
                }
            }
    
        }
    }
