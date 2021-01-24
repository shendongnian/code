    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class MainCharacterVarsScript : MonoBehaviour 
    {
        //These are base character stats
    
    	private int CharacterLife = 100; //  out of 125
    	private int CharacterStamina = 100; // out of 100
    	private int CharacterSight = 12; // out of 40
    	private int CharacterHunger = 100; // out of 100
    	private int CharacterExp = 0; // out of 100,000
    	private float CharacterStrength;
    
    	//These are the update stats
    
    	int NewCharacterLife;
    	int NewCharacterStamina;
    	int NewCharacterSight;
    	int NewCharacterHunger;
    	int NewCharacterExp;
    
    	float NewCharacterStrength;
    
    	// Use this for initialization
    	void Start () 
        {
    		float CharacterStrength = ((CharacterHunger * .2f) + (CharacterLife * .15f) + (CharacterStamina * .05f)); // out of 40
    
    		float CharacterSpeed = ((CharacterHunger * .1f) + (CharacterLife * .25f) + (CharacterStamina * .05f)); // out of 40
    		
    		Debug.Log ("Character life is " + CharacterLife);
    		Debug.Log ("Character Strength is " + CharacterStrength);
    		Debug.Log ("Character Stamina is " + CharacterStamina);
    		Debug.Log ("Character sight is " + CharacterSight);
    		Debug.Log ("Character Hunger is " + CharacterHunger);
    		Debug.Log ("Character EXP is " + CharacterExp);
    		Debug.Log ("Character Speed is " + CharacterSpeed);
    
    		NewCharacterLife = CharacterLife;
    		NewCharacterStamina = CharacterStamina;
    		NewCharacterSight = CharacterSight;
    		NewCharacterHunger = CharacterHunger;
    	    NewCharacterExp = CharacterExp;
    		NewCharacterStrength = CharacterStrength;
    	}
    	
    	// Update is called once per frame
    	void Update () 
        {
    		float CharacterStrength = ((CharacterHunger * .2f) + (CharacterLife * .15f) + (CharacterStamina * .05f)); // out of 40
    
    		float CharacterSpeed = ((CharacterHunger * .1f) + (CharacterLife * .25f) + (CharacterStamina * .05f)); // out of 40
    
    		if (CharacterLife != NewCharacterLife) 
            {
    			Debug.Log ("Character life is now " + NewCharacterLife);
    			NewCharacterLife = CharacterLife;
    		} 
    		else if (CharacterStamina != NewCharacterStamina) 
            { 
    			Debug.Log ("Character Stamina is now " + NewCharacterStamina); 
    			CharacterStamina = NewCharacterStamina;
    		} 
    		else if (CharacterSight != NewCharacterSight) 
            { 
    			Debug.Log ("Character Sight is now " + NewCharacterSight); 
    			CharacterSight = NewCharacterSight;
    		} 
    		else if (CharacterHunger != NewCharacterHunger) 
            {
    			Debug.Log ("Character Hunger is now " + NewCharacterHunger); 
    			CharacterHunger = NewCharacterHunger;
    		}
    		else if (CharacterExp != NewCharacterExp) 
            {
    			Debug.Log ("Character EXP is now " + NewCharacterExp);
    			CharacterExp = NewCharacterExp;
    		}
    	}
	}
