    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine; using UnityEngine.UI;
    
    public class GameManager : MonoBehaviour
    { 
        public Button[] TrailLevel; 
        public GameObject[] Cars, Trails;
        public Text text; 
        public int CurrentCarToSpawn = 0; 
    
        private void Start()
        { 
            // Load the current car. ADDED
            CurrentCarToSpawn  = PlayerPrefs.getInt("savedSelection", 0);
            InstantiateCar();
        }
    
        private void FixedUpdate()
        {
            UpdateCar();
        }
    
        public void InstantiateCar()
        {
            TrailLevel[CurrentCarToSpawn].gameObject.active = false;
            MineLevel[CurrentCarToSpawn+1].interactable = true;
            PlayerPrefs.SetInt("TrailCountA", PlayerPrefs.GetInt("TrailCountA") + 1);
            // Save Selection.  ADDED
            PlayerPrefs.SetInt("savedSelection", CurrentCarToSpawn);             
            PlayerPrefs.Save();
            CurrentCarToSpawn++;
            UpdateCar();
        }
    
        void UpdateCar()
        {
            int TrailCountA= PlayerPrefs.GetInt("TrailCountA", 1);
            for (int i = 0; i < TrailLevel.Length; i++)
            {
                if (i + 1 > TrailCountA)
                {
                     TrailLevel.interactable = false;
                }
                if (TrailLevel.interactable)
                {
                    Trains[CurrentCarToSpawn].gameObject.active = true;
                    Mines[CurrentCarToSpawn].gameObject.active = true;
                }
            }
            text.text = PlayerPrefs.GetInt("TrailCountA").ToString();
        }
    }
