    namespace SharedPartialCodeTryout.DataTypes
    {
    	public partial class Address
    	{
    		public Address(string name, int number, Direction dir)
    		{
    			this.Name = name;
    			this.Number = number;
    			this.Dir = dir;
    		}
    
    		public string Name { get; }
    		public int Number { get; }
    		public Direction Dir { get; }
    	}
    }
