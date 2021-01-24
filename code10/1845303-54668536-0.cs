    public class House
    {
        public int Number { get; set; }
        public string Street { get; set; }
        public ApartmentCollection Apartments { get; private set; }
    	
    	public House() {
    		Apartments = new ApartmentCollection(this);
    	}
    }
    
    public class Apartment
    {
    	private House house;
    	
        public int AptNumber { get; set; }
        public int AptRooms { get; set; }
        public House House {
    		get {
    			return house;
    		}
    		set {
    			house?.Apartments.Remove(this);
    			house = value;
    			house?.Apartments.Add(this);
    		}
    	}
        public List<Resident> Residents = new List<Resident>();
    }
    
    public class ApartmentCollection : Collection<Apartment> {
    	private readonly House parent;
    	
    	public ApartmentCollection(House parent) {
    		this.parent = parent;
    	}
    	
    	protected override void InsertItem(int index, Apartment item) {
    		if (item == null) {
    			throw new ArgumentNullException(nameof(item));
    		}
    		if (Contains(item)) {
    			return;
    		}
    		
    		base.InsertItem(index, item);
    		item.House = parent;
    	}
    	
    	protected override void SetItem(int index, Apartment item) {
    		if (item == null) {
    			throw new ArgumentNullException(nameof(item));
    		}
    		
    		Apartment oldItem = this[index];
    		if (oldItem.Equals(item)) {
    			return;
    		}
    		
    		int oldIndexOfItem = IndexOf(item);
    		base.SetItem(index, item);
    		oldItem.House = null;
    		item.House = parent;
    		
    		//If the item was in the collection before, remove it from its old position
    		if (oldIndexOfItem >= 0) {
                base.RemoveItem(oldIndexOfItem);
    		}
    	}
    	
    	protected override void RemoveItem(int index) {
    		Apartment removedItem = this[index];
    		base.RemoveItem(index);
    		removedItem.House = null;
    	}
    	
    	protected override void ClearItems() {
    		Apartment[] removedItems = new Apartment[Count];
    		CopyTo(removedItems, 0);
    		base.ClearItems();
    		foreach(Apartment removedItem in removedItems) {
    			removedItem.House = null;
    		}
    	}
    }
