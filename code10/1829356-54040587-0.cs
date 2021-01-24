    public class NumIndex:IComparable<NumIndex>
            {
                public int Number { get; set; }
                public int Index { get; set; }
    
                public int CompareTo(NumIndex other)
                {
                    return this.Number.CompareTo(other.Number);
                }
    
            }
    
            public static void Main(string[] args)
            {
                int[] nums = { 8, 4, 8, 1, 6, 3, 4, 32, 43, 5, 8, 95 };
    
                List<NumIndex> intArray = new List<NumIndex>();
                int i = 0;
                foreach (int num in nums)
                {
                    NumIndex newNum = new NumIndex() { Number = num, Index = i++ };
                    int index = intArray.BinarySearch(newNum);
                    if (index > -1)
                    {
                        //Item already found, you decide what to do with it, I added all numbers
                    }
                    else index = ~index;
    
                    intArray.Insert(index, newNum);
                }
    
                NumIndex dummy = new NumIndex() { Number = 18, Index = 0 };
    
                int findItemIndex = intArray.BinarySearch(dummy);
                if (findItemIndex < -1) throw new Exception("Item not found");
                int itemIndex = intArray[].Index;
            }
