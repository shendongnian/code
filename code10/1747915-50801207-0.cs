    using System;
    using System.Collections.Generic;
    using UnityEngine;
    
    [Serializable]
    public struct InventoryCollection
    {
        public string Name;
        public List<Sprite> Sprites;
    }
    
    public class Inventory: MonoBehaviour
    {
        public List<InventoryCollection> ObjectTypesToBuy = new List<InventoryCollection>();
    }
