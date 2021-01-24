    using UnityEngine;
    
    public class SimpleCountDown : MonoBehaviour
    {
        [Header("The Objects")]
        public GameObject CountDownObject;
        public GameObject FlowerObject;
    
        [Header("Settings")]
        // Here you can adjust the delay times
        public float StartOffset = 3;
        public float FlowerOffset = 8;
    
        [Header("Debug")]
        public float startTimer;
        public float flowerTimer;
    
        public bool isStartDelay;
        public bool isFlowerDelay;
    
        private void Start()
        {
            startTimer = StartOffset;
            flowerTimer = FlowerOffset;
            isStartDelay = true;
        }
    
        private void Update()
        {
            if (!isStartDelay && !isFlowerDelay) return;
    
            if (isStartDelay)
            {
                startTimer -= Time.deltaTime;
                if (startTimer <= 0)
                {
                    HideCountdown();
                    isStartDelay = false;
                    isFlowerDelay = true;
                }
            }
    
            if (isFlowerDelay)
            {
                flowerTimer -= Time.deltaTime;
                if (flowerTimer <= 0)
                {
                    ShowFlower();
                    isFlowerDelay = false;
                    this.enabled = false;
                }
            }
        }
    
        private void HideCountdown()
        {
            CountDownObject.SetActive(false);
        }
    
        private void ShowFlower()
        {
            FlowerObject.SetActive(true);
        }
    }
