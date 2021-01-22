        // all subsets of given set 
        static void numbcomb (string [] list) 
        {            
            int gelen = (int)Math.Pow(2,list.Length); // number of subsets (2^n)
            string [] result = new string [gelen]; // array with subsets as elements
            for(int i=0; i<gelen; i++) // filling "result"
            {
                for(int j=0;j<list.Length;j++)  // 0,1,2 (for n=3)
                {
                    int t = (int)Math.Pow(2, j); // 1,2,4 (for n=3)
                    if ((i&t)!=0)  // the MAIN THING in the program
                                   // i can be:
                                   // 000,001,010,011,100,101,110,111
                                   // t can be: 001,010,100
                                   // take a pensil and think about!
                    { result[i]+=list[j]+" ";} // add to subset
                }
                Console.Write("{0}: ",i);// write subset number
                Console.WriteLine(result[i]);//write subset itself
            }
        }
