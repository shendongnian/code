    using UnityEngine;
    [RequiresComponent (typeof(Rigidbody))]
    public class Puncher : MonoBehaviour {
      Rigidbody _rb;
      bool _isPunching;
      
      void Awake () {
        _rb = GetComponent<Rigidbody> ()
      }
      
      void Update () {
        if (!_isPunching && Input.GetKeyDown(KeyCode.Space)) {
          StartCoroutine(Punch(0.5f, 1.25f, transform.forward));
        }
      }
      
      IEnumerator Punch(float time, float distance, Vector3 direction) {
        _isPunching = true;
        var timer = 0.0f;
        var orgPos = transform.position;
        direction.Normalize();
        while (timer <= time) {
          _rb.MovePosition (orgPos + (Mathf.Sin(timer / time * Mathf.PI) + 1.0f) * direction);
          yield return null;
          timer += Time.deltaTime;
        }
        transform.position = orgPos;
        _isPunching = false;
      }
    }
