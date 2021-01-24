    using UnityEngine;
    using UnityEngine.AI;
    using System.Collections;
    [RequireComponent(typeof(NavMeshAgent))]
    public class wheatleyfollow : MonoBehaviour {
      public GameObject ThePlayer;
      public float TargetDistance;
      public float AllowedRange = 500;
      public int AttackTrigger;
      public RaycastHit Shot;
      private NavMeshAgent agent;
      private NavMeshPath path;
      void Start() {
        path = new NavMeshPath();
        agent = GetComponent<NavMeshAgent>();
      }
      void Update() {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot)) {
          TargetDistance = Shot.distance;
          if (TargetDistance < AllowedRange && AttackTrigger == 0) {
            agent.CalculatePath(ThePlayer.transform.position, path);
            agent.SetPath(path);
          }
        }
      }
      void OnTriggerEnter() {
        AttackTrigger = 1;
      }
      void OnTriggerExit() {
        AttackTrigger = 0;
      }
    }
