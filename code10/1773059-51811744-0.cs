    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class board : MonoBehaviour {
	// Use this for initialization
    public GameObject quad;
	void Start () {
		for(int j=-4;j<4;j++)
        {
            for(int i=-4;i<4;i++)
            {
                var gameObject=Instantiate(quad,new Vector3(i,j,0),Quaternion.identity);
                if (j % 2 == 0)
                {
                    if (i % 2 == 0)
                        gameObject.GetComponent<MeshRenderer>().material = (Material)Resources.Load("bone");
                    else
                        gameObject.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Charcoal");
                }
                else
                {
                    if (i % 2 != 0)
                        gameObject.GetComponent<MeshRenderer>().material = (Material)Resources.Load("bone");
                    else
                        gameObject.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Charcoal");
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    }
