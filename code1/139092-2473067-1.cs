	public class Donator :IComparable<Donator>
	{
	  public string name { get; set; }
	  public string comment { get; set; }
	  public double amount { get; set; }
	  public int CompareTo(Donator other)
	  {
	     return amount.CompareTo(other.amount);
	  }
	}
