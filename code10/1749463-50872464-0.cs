    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class generateUI : MonoBehaviour
    {
        public GameObject canvas;
        public GameObject Panel;
        public GameObject image;
        int size = 40;
    
        private float scaler = 0.0125f;
        void Start()
        {
            Panel.transform.SetParent(canvas.transform, false);
            GameObject[] tiles = new GameObject[size];
            Vector3 change = new Vector3(20 * scaler, 0, 0);
            for (int i = 0; i < size; i++)
            {
                tiles[i] = GameObject.Instantiate(image, transform.position, transform.rotation);
    
                tiles[i].transform.position += change;
                tiles[i].transform.SetParent(Panel.transform, false);
            }
        }
    }
