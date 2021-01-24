    using UnityEngine;
    using System.Collections;
    using UnityEditor;
    public class Item
    {
        [CreateAssetMenu(menuName = "new Item")]
        public static void CreateMyAsset()
        {
            public GameObject prefab;
            // you can add other variables here aswell, like cost, durability etc.
        }
    }
