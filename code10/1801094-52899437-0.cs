        public static Dictionary<string, int> YourDictionary()
        {
            Dictionary<string, int> returnDict = new Dictionary<string, int>();
            returnDict.Add("L1andL4", 1);
            returnDict.Add("L5andL6", 2);
            returnDict.Add("L1,L4andL5,L6", 3);
            returnDict.Add("L2andL1,L4,L5,L6", 4);
            returnDict.Add("L3andL2,L1,L4,L5,L6", 5);
            return returnDict;
        }
