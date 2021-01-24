    using System;
    using System.Collections;
    using UnityEngine;
    
    public class MoveController : MonoBehaviour
    {
        public float moveTime;
        public AnimationCurve moveSpeedCurve;
        public AnimationCurve movePositionCurve;
    
        public void StartMoving(Vector2 destination, Action action = null)
        {
            StartCoroutine(Move(destination, action));
        }
    
        IEnumerator Move(Vector3 destination, Action action = null)
        {
            float currentTime = 0;
            float perc = 0;
            Vector3 currentPos = transform.localPosition;
    
            while (perc != 1)
            {
                currentTime += Time.deltaTime;
                if (currentTime > moveTime)
                {
                    currentTime = moveTime;
                }
                perc = moveSpeedCurve.Evaluate(currentTime / moveTime);
                transform.localPosition = Vector2.LerpUnclamped(currentPos, destination, movePositionCurve.Evaluate(perc));
                yield return null;
            }
    
            if (action != null)
                action();
        }
    }
