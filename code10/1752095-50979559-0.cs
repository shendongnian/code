    using System.Collections;
    using UnityEngine;
    
    public class Follower : MonoBehaviour
    {
      public GameObject player;
      public float delay = 0f;
      public float speed = .5f;
      bool isReady = false;
    
      void Start()
      {
        StartFollowing();
      }
    
      public void StartFollowing()
      {
        StartCoroutine(WaitThenFollow(delay));
      }
    
      IEnumerator WaitThenFollow(float delay)
      {
        yield return new WaitForSeconds(delay);
        isReady = true;
        Debug.Log(gameObject.name);
        Debug.Log(Time.time);
      }
    
      void FixedUpdate()
      {
        if (isReady && player != null)
        {
          Vector2 toTarget = player.transform.position - transform.position;
          transform.Translate(toTarget * speed * Time.deltaTime);
        }
      }
    }
