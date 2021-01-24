    class Asset
    {
        public Asset Child { get; set; } = null;
    }
    
    static void main (string[] args) 
    {
         Asset asset = new Asset();
         while (asset.Child != null) 
         {
             asset = asset.Child;
         }
         //asset is now the bottom most child
    }
