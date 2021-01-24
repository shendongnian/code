    GameObject itemPrefab = Resources.Load<GameObject>("Prefabs/ProductButtonPrefab");
    for (int i = 0; i < productsInCategory.Count; i++)
    {
         print("PinCat Count = " + productsInCategory.Count);
         Item item = productsInCategory[i];
               
         GameObject clone = GameObject.Instantiate(itemPrefab);
         // ...
    }
