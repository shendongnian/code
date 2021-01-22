    using System;
    
    namespace Test
    {
        class MainClass
        {
            static int[] currentDeck = new int[54] {
                    0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D,
                    0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D,
                    0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D,
                    0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D,
                    0x50, 0x51 };
            
            static void printParts (int num)
            {
                int card  = currentDeck[num];
                int suit  = (card & 0xF0) >> 4;
                int value = (card & 0x0F);
        
                Console.Out.WriteLine(
                        String.Format ("Card: {0:x4},   ", card) +
                        String.Format ("Suit: {0:x4},   ", suit) +
                        String.Format ("Value: {0:x4}", value ));
            }
    
    
            public static void Main (string[] args)
            {
                printParts(  7 );
                printParts( 18 );
                printParts( 30 );
                printParts( 48 );
            }
        }
    }
