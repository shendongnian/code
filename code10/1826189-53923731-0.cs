    using UnityEngine;
    using UnityEngine.EventSystems;
    
    public class MoveStick : MonoBehaviour, IDragHandler, IEndDragHandler {
    
        public Transform leftTarget;
        public Transform rightTarget;
        public float rotateSpeed;
    
        [Space]
    
        Vector2 joyStartPosition;
        public Transform stick;
        public Transform topTarget;
        public float speed;
    
        bool goingUp;
    
        void Start()
        {
            joyStartPosition = transform.position;
            goingUp = false;
        }
    
        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
            if (transform.localPosition.y > 80f || transform.localPosition.x > 50 || transform.localPosition.x < -50)
            {
                goingUp = true;
    
                var step = speed * Time.deltaTime;
                stick.position = Vector3.MoveTowards(stick.position, topTarget.position, step);
    
                Debug.Log("Going  up: " + goingUp);
            }
            else if (transform.localPosition.y < 80f)
            {
                goingUp = false;
                Debug.Log("Going  up: " + goingUp);
            }
            if (transform.localPosition.x > 80 && transform.localPosition.y > 80)
            {
                stick.rotation = Quaternion.RotateTowards(stick.rotation, rightTarget.rotation, rotateSpeed * Time.deltaTime);
            }
            else if (transform.localPosition.x < -80 && transform.localPosition.y > 80)
            {
                stick.rotation = Quaternion.RotateTowards(stick.rotation, leftTarget.rotation, rotateSpeed * Time.deltaTime);
            }
        }
    
        public void OnEndDrag(PointerEventData eventData)
        {
            transform.position = joyStartPosition;
            eventData.position = joyStartPosition;
            Debug.Log("Joystick is not moving");
            goingUp = false;
        }
    
    }
