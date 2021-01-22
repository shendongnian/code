    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    
    namespace test {
        class Program {
            static void Main(string[] args) {
                String mainString="//BUY/SELL//ORDERTIME//RT//QTY//BROKERAGE//NETRATE//AMOUNTRS//RATE//SCNM//";
                
            
                Hashtable ht = createHashTable(mainString);
    
    
    
                if (hasValue("RA", ht)) {
                    Console.WriteLine("Matched RA");
                } else {
                    Console.WriteLine("Didnt Find RA");
                }
    
    
                if (hasValue("RATE", ht)) {
                    Console.WriteLine("Matched RATE");
                }
    
    
                Console.Read();
    
            }
    
    
            public static Hashtable createHashTable(string strToSplit) {
                Hashtable ht = new Hashtable();
                int iCount = 0;
    
                string[] words = strToSplit.Split(new Char[] { '/', '/', '/' });
                foreach (string word in words) {
    
                    ht.Add(iCount++, word);
                }
    
                return ht;
            }
            public static bool hasValue(string strValuetoSearch, Hashtable ht) {
    
                return ht.ContainsValue(strValuetoSearch);
            
            }
            
        }
    
    }
