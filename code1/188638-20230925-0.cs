    private ManagementObject GetItem(ManagementObjectCollection collection, int index)
    {
                //TODO: do null handling 
    
                IEnumerator enumerator = collection.GetEnumerator();
    
                int currentIndex = 0;
                while (enumerator.MoveNext())
                {
                    if (currentIndex == index)
                    {
                        return enumerator.Current as ManagementObject;
                    }
    
                    currentIndex++;
                }
                
                throw new ArgumentOutOfRangeException("Index out of range");
     }
