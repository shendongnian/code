	public class Item
	{
		public Item() {}
		public Item(string name)
		{
			Name = name;
			Caption = name; //defaulting name to caption
		}
		public Item(string name, int index) : this(name)
		{
			Index = index;
		}
		public Item(string name, int index, string caption) : this(name, int)
		{
			Caption = caption;
		}
		public string Name {get; set;}
		public int Index {get; set;}
		public string Caption {get; set;}
	} 
