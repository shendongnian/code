    using UnityEngine;
    using System.Collections;
        
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]    
    public class WeaponObject : ScriptableObject {
        public string objectName = "New Weapon";
        public Vector3 offSetPosition;
        public Vector3 startOffsetRotation;
        public float fireRate;
        // Using a gameObject to store the weapon model so you can technical
        // store the firing point.
        public GameObject weaponModel;  
    }
