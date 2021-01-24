    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class Pad1 : MonoBehaviour {
	// Use this for initialization
	void Start () {
        //Collider padcollider = GetComponent<SphereCollider>();
	}
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<PlayerController>();
            PlayerController.AtSpawn = false;
            PlayerController.AtPad1 = true;
            
        }
    }
    public static void MoveFromPad1 ()
    {
        if (PlayerController.MoveSpaces != 0)
        {
            PlayerController.MoveSpaces -= 1;
            if (PlayerController.ThisPlayersTurn == true)
            {
                if (PlayerController.MoveSpaces == 1)
                {
                    PlayerController.Playeragent.SetDestination(PadManager.IntPad2.transform.position);
                    PlayerController.MoveSpaces -= 1;
                }
                if (PlayerController.MoveSpaces == 2)
                {
                    PlayerController.Playeragent.SetDestination(PadManager.IntPad3.transform.position);
                    PlayerController.MoveSpaces -= 1;
                }
                if (PlayerController.MoveSpaces == 3)
                {
                    PlayerController.Playeragent.SetDestination(PadManager.IntPad4.transform.position);
                    PlayerController.MoveSpaces -= 1;
                }
                if (PlayerController.MoveSpaces == 4)
                {
                    PlayerController.Playeragent.SetDestination(PadManager.IntPad5.transform.position);
                    PlayerController.MoveSpaces -= 1;
                }
                if (PlayerController.MoveSpaces == 5)
                {
                    PlayerController.Playeragent.SetDestination(PadManager.IntPad6.transform.position);
                    PlayerController.MoveSpaces -= 1;
                }
                if (PlayerController.MoveSpaces == 6)
                {
                    PlayerController.Playeragent.SetDestination(PadManager.IntGoal.transform.position);
                    PlayerController.MoveSpaces -= 1;
                }
            }
        }
    }
