    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class LookAtObject : MonoBehaviour {
    public float Speed = 0.001f;
    private Transform _go;
	// Update is called once per frame
	void Update ()
    {
        if (_go == null) return;
        Vector3 direction = _go.transform.position - transform.position;
        Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Speed * Time.time);
    }
    public void AdjustOrientation(Transform go)
    {
        _go = go;
    }
    }
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class OnClick : MonoBehaviour
    {
    private LookAtObject _lookAt;
    public void Start()
    {
        _lookAt = FindObjectOfType<LookAtObject>();
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                _lookAt.AdjustOrientation(hit.transform);
            }
        }
    }
    }
