    using System.Collections.Generic;
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "Assets/New Store", menuName = "Sprites-Store")]
    public class SpriteStoreCotnainer : ScriptableObject
    {
        public List<StoreSpriteItem> SpriteItems = new List<StoreSpriteItem>();
    
        // you can/should also implement methods here as in any usual component!
    }
