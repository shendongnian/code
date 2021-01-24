            [Serializable]
            public class ItemEntry
            {
                public string Name;
                public string Data;
                public int Amount;
    
                //parameterless constructor for XmlSerializer
                public ItemEntry()
                {
                }
    
                public ItemEntry(string iName, string idata, int iAmount)
                {
                    Name = iName;
                    Data = idata;
                    Amount = iAmount;
                }
            }
