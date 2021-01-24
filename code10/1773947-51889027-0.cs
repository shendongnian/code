    using System.Collections;
    using UnityEngine;
    public class CountDown : MonoBehaviour
    {
        public GameObject CountDownObject;
        public GameObject flowerObject;
    
        private void Start()
        {
            StartCoroutine(Delay());
        }
    
        private IEnumerator Delay()
        {
            yield return new WaitForSeconds(3);
            HideCountdown();
            StartCoroutine(FlowerDelay());
        }
    
        private void HideCountdown()
        {
            CountDownObject.SetActive(false);
        }
    
        private IEnumerator FlowerDelay()
        {
            yield return new WaitForSeconds(8);
            ShowFlower();
        }
    
        private void ShowFlower()
        {
            flowerObject.SetActive(true);
        }
    }
