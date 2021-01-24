    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class RocksPlants : MonoBehaviour {
    
    	GameObject Rockgroup_01;
    	GameObject Rockgroup_02;
    	GameObject Rockgroup_03;
    	GameObject Rockgroup_04;
    
    
    	// Use this for initialization
    	void Start () {
    		
    		Rockgroup_01 = GameObject.Find("RockGroup_1");
    		Rockgroup_02 = GameObject.Find("RockGroup_2");
    		Rockgroup_03 = GameObject.Find("RockGroup_3");
    		Rockgroup_04 = GameObject.Find("RockGroup_4");
    
    		InvokeRepeating ("Rocksplants", 0.5f, 2.0f);
    
    	}
    
    	void Rocksplants() {
    
    		Rockgroup_01.SetActive(false);
    		Rockgroup_02.SetActive(false);
    		Rockgroup_03.SetActive(false);
    		Rockgroup_04.SetActive(false);
    
    
    		int rndrockgroupright = Random.Range (1, 5);
    
    		if        (rndrockgroupright == 1) {
    			Rockgroup_01.SetActive (true);
    
    		} else if (rndrockgroupright == 2) {
    			Rockgroup_02.SetActive (true);
    
    		} else if (rndrockgroupright == 3) {
    			Rockgroup_03.SetActive (true);
    
    		} else if (rndrockgroupright == 4) {  
    			Rockgroup_04.SetActive (true);
    
    		}	
    	}
