        public struct ValueRange 
        { 
           public int LowVal; 
           public int HiVal; 
           public bool Contains (int CandidateValue) 
           { return CandidateValue >= LowVal && CandidateValue <= HiVal; } 
           public ValueRange(int loVal, int hiVal)
           {
              LowVal = loVal;
              HiVal = hiVal;
           }
       }
        
        public class ValueRangeCollection: SortedList<int, ValueRange> 
        { 
            public bool Contains(int candValue) 
            {  
                foreach ( ValueRange valRng in Values)
                    if (valRng.Contains(candValue)) return true;
                return false; 
            }
            public void Add(int loValue, int hiValue)
            {
                Add(loValue, new ValueRange(loValue, hiValue));
            }
        }
