    foreach (KeyValuePair<Dude, IConsumable[]> i in KeyValuePair<Dude, IConsumale[]>[] {
        foreach(IConsumable consumable in i.Value) {   
            if(consumable is IFood){
                //Code for food
            }
            if(consumable is IDrink){
                //Code for drinks
            }
            //You can even be more specific
            if(consumable is Beer){ //Code for Beer }
        }
    }
