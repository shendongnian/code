    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class Inventory : MonoBehaviour
    {
        public static Inventory instance;
        private void Awake()
        {
            instance = this;
        }
        public float ResourceStone;
    // Use this for initialization
        void Start()
        {
            ResourceStone = 0;
        }
    }
