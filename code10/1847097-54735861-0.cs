    using UnityEngine;
    public class Test : MonoBehaviour
    {
        private float distance = 10;
        private float offset = -4;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.transform.position = new Vector3
                {
                    x = offset += 1.5f,
                    y = 0,
                    z = 0
                };
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if(Physics.Raycast(ray, out RaycastHit hit, distance))
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
