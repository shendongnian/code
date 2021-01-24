    private List<Collider> UsersInsideZone = new List<Collider>();
    
    private void OnTriggerEnter(Collider col)
    {
        // you would give them tags instead of a layer
        if(col.gameObject.tag != "player") return;
        // or alternative set which layers can collide at all in the Physics settings
        if(UsersInsideZone.Contains(col)) return;
        UsersInsideZone.Add(col);
    }
    
    private void OnTriggerExit(Collider col)
    {
        // you would give them tags instead of a layer
        if(col.gameObject.tag != "player") return;
        // or alternative set which layers can collide at all in the Physics settings
        if(!UsersInsideZone.Contains(col)) return;
        UsersInsideZone.Remove(col);
    }
    
    private void Update()
    {
        // run through all available lines
        for (int i = 0; i < lines.Count; i++)
        {
            var currentLine = lines[i];
            // if under player count -> set enabled and set positions
            if(i < amountofplayers)
            {
                currentLine.enabled = true;
                // set target to player at same index as this line
                currentLine.SetPosition(0, transform.position);
                currentLine.SetPosition(1, UsersInsideZone[i].gameObject.transform.position);
            }
            // otherwise set disabled
            else   
            {
                currentLine.enabled = false;
            }
        }
    }
