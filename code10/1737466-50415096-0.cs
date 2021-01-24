    using System.Collections.Generic;
    using UnityEngine;
    
    public class CollisionDetection: MonoBehaviour
    
    {
        static private List<KeyValuePair<GameObject, GameObject>> collisionList =
            new List<KeyValuePair<GameObject, GameObject>>();
    
        void OnTriggerEnter(Collider other)
        {
            //Debug.Log("Trigger Entered");
    
            //Get the two Objects involved in the collision
            GameObject col1 = this.gameObject;
            GameObject col2 = other.gameObject;
    
            //Add to the collison List
            RegisterTouchedItems(collisionList, col1, col2);
        }
    
        void OnTriggerExit(Collider other)
        {
            //Debug.Log("Trigger Exit");
    
            //Get the two Objects involved in the collision
            GameObject col1 = this.gameObject;
            GameObject col2 = other.gameObject;
    
            //Remove from the collison List
            UnRegisterTouchedItems(collisionList, col1, col2);
        }
    
        public static bool IsTouching(GameObject obj1, GameObject obj2)
        {
            int matchIndex = 0;
            return _itemExist(collisionList, obj1, obj2, ref matchIndex);
        }
    
        private void UnRegisterTouchedItems(List<KeyValuePair<GameObject, GameObject>> existingObj, GameObject col1, GameObject col2)
        {
            int matchIndex = 0;
    
            //Remove if it exist
            if (_itemExist(existingObj, col1, col2, ref matchIndex))
    
            {
                existingObj.RemoveAt(matchIndex);
            }
        }
    
        private void RegisterTouchedItems(List<KeyValuePair<GameObject, GameObject>> existingObj, GameObject col1, GameObject col2)
        {
            int matchIndex = 0;
    
            //Add if it doesn't exist
            if (!_itemExist(existingObj, col1, col2, ref matchIndex))
    
            {
                KeyValuePair<GameObject, GameObject> item = new KeyValuePair<GameObject, GameObject>(col1, col2);
                existingObj.Add(item);
            }
        }
    
        private static bool _itemExist(List<KeyValuePair<GameObject, GameObject>> existingObj, GameObject col1,
        GameObject col2, ref int matchIndex)
        {
            bool existInList = false;
            for (int i = 0; i < existingObj.Count; i++)
            {
                //Check if key and value exist and vice versa
                if ((existingObj[i].Key == col1 && existingObj[i].Value == col2) ||
                        (existingObj[i].Key == col2 && existingObj[i].Value == col1))
                {
                    existInList = true;
                    matchIndex = i;
                    break;
                }
            }
            return existInList;
        }
    
    }
