    using System;
    using System.IO;
    class BinaryRW {
        static void Main(string[] args) {
            BinaryWriter binWriter = new BinaryWriter(
                    Console.OpenStandardOutput()
                    );
            BinaryReader binReader = new BinaryReader(
                    Console.OpenStandardInput()
                    );
            int delta;
            
            if ( ! int.TryParse( args[0], out delta ) || delta < 0 ) {
                Console.WriteLine(
                        "Provide a non-negative delta on the command line"
                        );
            } else {       
                try  {
                    while ( true ) {
                        int bin = binReader.ReadByte();
                        byte bout = (byte) ( ( bin + delta ) % 256 );
                        binWriter.Write( bout );
                    }
                }
                catch(EndOfStreamException) { }
                catch(ObjectDisposedException) { }
                catch(IOException e) {
                    Console.WriteLine( e );        
                }
                finally {
                    binWriter.Close();
                    binReader.Close();
                
                }
            }
        }
    }
    E:\Test> xxd bin
    0000000: 3031 3233 3435 0d0a 0d0a                 012345....
    E:\Test> b 0 < bin | xxd
    0000000: 3031 3233 3435 0d0a 0d0a                 012345....
    E:\Test> b 32 < bin | xxd
    0000000: 5051 5253 5455 2d2a 2d2a                 PQRSTU-*-*
    E:\Test> b 257 < bin | xxd
    0000000: 3132 3334 3536 0e0b 0e0b                 123456....
