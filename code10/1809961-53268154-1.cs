     class MyDerivedList : MyList<MyDerivedItem>
     {
        int GetID(int index)
        {
            return ItemList[index].ID;
        }
        
        string GetName(int index)
        {
            return ItemList[index].Name; 
        }
    }
