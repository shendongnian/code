    public class Item { }
    public class Food : Item
    {
	    public void Eat() { }
    }
    public class Clothes : Item
    {
	    public void Wear() {}
    }
    public void DecideWhatToDo(Item item)
    {
	    switch (item)
	    {
		    case Food f:
			    f.Eat();
			    break;
		    case Clothes c:
			    c.Wear();
			    break;
	    }
    }
