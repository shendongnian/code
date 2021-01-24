    using UnityEngine;
    public class RotFollow : MonoBehaviour
    {
        [SerializeField] Transform carTransform;
        [SerializeField] float smoothTime = .4f; 
        
        float currentYAngle;
        float targetYAngle;
        float angleVel;
        void Update()
        {
            targetYAngle = carTransform.rotation.eulerAngles.y;
            currentYAngle =  Mathf.SmoothDampAngle(currentYAngle, targetYAngle, ref angleVel, smoothTime);
            transform.rotation = Quaternion.Euler(
                                            transform.rotation.eulerAngles.x,
                                            currentYAngle, 
                                            transform.rotation.eulerAngles.z);
            }
        }
