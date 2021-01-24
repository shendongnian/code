    public void pickUpItem(Item item)
    {
       this.playerItem = true;
       this.itemInHand = item;
       Debug.Log(string.Format("You picked up a {0}.", item.name));
    }
    public void useItem()
    {
        if (this.itemInHand != null)
        {
           Debug.Log(string.Format("You used a {0}.", this.itemInHand.name));
        }
    }
