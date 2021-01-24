    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Scaling : MonoBehaviour
    {
        public GameObject objectToScale;
        public float duration = 1f;
        public Vector3 minSize;
        public Vector3 maxSize;
        public bool scaleUp = false;
        public Coroutine scaleCoroutine;
        public bool automatic = false;
    
        private void Start()
        {
            objectToScale.transform.localScale = minSize;
        }
    
        private void Update()
        {
            if(automatic)
            {
                Scale();
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.G))
                {
                    Scale();
                }
            }
        }
        private Scale()
        {
            scaleUp = !scaleUp;
    
            if (scaleCoroutine != null)
                StopCoroutine(scaleCoroutine);
    
            if (scaleUp)
            {
                scaleCoroutine = StartCoroutine(ScaleOverTime(objectToScale, maxSize, duration));
            }
            else
            {
                scaleCoroutine = StartCoroutine(ScaleOverTime(objectToScale, minSize, duration));
            }
        }
    
        private IEnumerator ScaleOverTime(GameObject targetObj, Vector3 toScale, float duration)
        {
            float counter = 0;
            Vector3 startScaleSize = targetObj.transform.localScale;
    
            while (counter < duration)
            {
                counter += Time.deltaTime;
                targetObj.transform.localScale = Vector3.Lerp(startScaleSize, toScale, counter / duration);
    
                yield return null;
            }
        }
    }
