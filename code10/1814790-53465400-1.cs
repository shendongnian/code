    private void OnTriggerEnter(Collider other)
    	{
    		checkPlate();
    	}
    		
    void checkPlate(){
        
    	if (countSameIngredients > 2)
    	{
    
    		//Destroying last 3 same ingredients 
    		Destroy(ingredients[ingredients.Count - 3].gameObject);
    		Destroy(ingredients[ingredients.Count - 2].gameObject);
    		Destroy(ingredients[ingredients.Count - 1].gameObject);
    
    		ingredients.RemoveAt(ingredients.Count - 3);
    		ingredients.RemoveAt(ingredients.Count - 2);
    		ingredients.RemoveAt(ingredients.Count - 1);
    		...		
    	}
    	
    	...
        
    }
    
