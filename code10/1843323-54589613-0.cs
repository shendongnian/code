    using UnityEngine;
    
    public class weapon: MonoBehaviour
    {
        public Transform firePoint;
        public GameObject BumperPrefab;
        public float lifetime = 0.2f;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            attack();
        }
    
    }
    void attack()
    {
        var bumper = (GameObject) Instantiate(BumperPrefab, firePoint.position, firePoint.rotation);
        Destroy(bumper, lifetime);
    }
