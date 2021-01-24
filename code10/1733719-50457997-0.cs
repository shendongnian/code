    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class BaseDoorScript : MonoBehaviour {
    public float NeededKeyNumber;
    public float TpDelay;
    
    public bool CanOpen;
    public bool NeedsKey;
    public bool Playerisatdoor;
    //Door in the hallway
    public GameObject Entrancedoor;
    public bool isbossdoor;
    public bool playerisentering;
    //Door in the bossroom
    public GameObject ExitBossdoor;
    public GameObject SpawnBossRoom;
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Playerisatdoor = true;
            Debug.Log("Player Is Here");
            //collision.transform.position = ExitBossdoor.transform.position;
            if (CanOpen == true && Playerisatdoor == true)
            {
                var PlayerKey = collision.GetComponent<KeyScript>().KeyNumber;
                if (NeedsKey == true)
                {
                    //if (Input.GetButton("EnterDoor"))
                    //{
                        if (PlayerKey == NeededKeyNumber)
                        {
                            
                            if (isbossdoor == false)
                            {
                                collision.transform.position = ExitBossdoor.transform.position;
                                SpawnBossRoom.SetActive(true);
                            }
                            if (isbossdoor == true)
                            {
                                collision.transform.position = Entrancedoor.transform.position;
                                SpawnBossRoom.SetActive(false);
                            }
                        }
                    //}
                }
                if (NeedsKey == false)
                {
                    if ( playerisentering == true
                        //Input.GetButton("EnterDoor") || Input.GetKey(KeyCode.Q)
                        )
                    {
                        Debug.Log("ButtonPressed");
                        if (isbossdoor == false)
                        {
                            collision.transform.position = ExitBossdoor.transform.position;
                            SpawnBossRoom.SetActive(true);
                        }
                        if (isbossdoor == true)
                        {
                            collision.transform.position = Entrancedoor.transform.position;
                            SpawnBossRoom.SetActive(false);
                        }
                    }
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Playerisatdoor = false;
        }
    }
    private void Update()
    {
        if(Playerisatdoor == true)
        {
            if(Input.GetButton("EnterDoor") || Input.GetKey(KeyCode.Q))
            {
                StartCoroutine("TeleportPlayer");
            }
            else
            {
                playerisentering = false;
            }
        }
    }
    public IEnumerator TeleportPlayer ()
    {
        yield return new WaitForSeconds(TpDelay);
        playerisentering = true;
        yield return new WaitForSeconds(1);
    }
    }
    // RoomKey Numbers:
    /* 
 
    */
