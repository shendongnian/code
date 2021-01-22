    public ItemCollection Items{
        get{
            return innerItems.Items;
        }set{
            innerItems.Items.Clear();
            foreach (var item in value){
                innerItems.Items.Add(item);
            }
        }
    }
