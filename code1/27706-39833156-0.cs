     static class Program
    {          
        static void Main(string[] args)
        {
            var input = new List<String>();
            for (int k = 0; k < 18; ++k)
            {
                input.Add(k.ToString());
            }
            var result = splitListIntoSmallerLists(input, 15);            
            int i = 0;
            foreach(var resul in result){
                Console.WriteLine("------Segment:" + i.ToString() + "--------");
                foreach(var res in resul){
                    Console.WriteLine(res);
                }
                i++;
            }
            Console.ReadLine();
        }
        private static List<List<T>> splitListIntoSmallerLists<T>(List<T> i_bigList,int i_numberOfSmallerLists)
        {
            if (i_numberOfSmallerLists <= 0)
                throw new ArgumentOutOfRangeException("Illegal value of numberOfSmallLists");
            int normalizedSpreadRemainderCounter = 0;
            int normalizedSpreadNumber = 0;
            //e.g 7 /5 > 0 ==> output size is 5 , 2 /5 < 0 ==> output is 2 	        
            int minimumNumberOfPartsInEachSmallerList = i_bigList.Count / i_numberOfSmallerLists;                        
            int remainder = i_bigList.Count % i_numberOfSmallerLists;
            int outputSize = minimumNumberOfPartsInEachSmallerList > 0 ? i_numberOfSmallerLists : remainder;
            //In case remainder > 0 we want to spread the remainder equally between the others         
            if (remainder > 0)
            {                
                normalizedSpreadNumber = (int)Math.Floor((double)i_numberOfSmallerLists/remainder);
            }
            List<List<T>> retVal = new List<List<T>>(outputSize);
            int inputIndex = 0;            
            for (int i = 0; i < outputSize; ++i)
            {
                retVal.Add(new List<T>());
                if (minimumNumberOfPartsInEachSmallerList > 0)
                {
                    retVal[i].AddRange(i_bigList.GetRange(inputIndex, minimumNumberOfPartsInEachSmallerList));
                    inputIndex += minimumNumberOfPartsInEachSmallerList;
                }
                //If we have remainder take one from it, if our counter is equal to normalizedSpreadNumber.
                if (remainder > 0)
                {
                    if (normalizedSpreadRemainderCounter == normalizedSpreadNumber-1)
                    {
                        retVal[i].Add(i_bigList[inputIndex]);
                        remainder--;
                        inputIndex++;
                        normalizedSpreadRemainderCounter=0;
                    }
                    else
                    {
                        normalizedSpreadRemainderCounter++;
                    }
                }
            }
            return retVal;
        }      
      
    }
