    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour {
      public float speed, waveSpeed;
      new Rigidbody2D rigidbody;
      public bool random;
      
      // Use this for initialization
      void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        if (random) {
          rigidbody.velocity = Random.value * transform.right * speed;
        } else {
          rigidbody.velocity = transform.right * speed;
        }
      }
      float angle = 0;
      // Use this for physics calculations
      void FixedUpdate () {
        var wave = Mathf.Sin(angle += waveSpeed); // goes from -1 to +1
        var p = rigidbody.position;
        p.y = wave; // or: yCenter + yHeight * wave
        rigidbody.position = p;
      }
    }
