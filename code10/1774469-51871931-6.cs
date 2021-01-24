        using UnityEngine;
    
        public class ScriptThatUsesStore : MonoBehaviour
        {
    
            public SpriteStoreCotnainer Store;
    
            public void DoSomthingWithStore()
            {
                // example: just get the first List element
                Sprite someSprite = Store.SpriteItems[0].sprite;
            }
        }
