    public enum FuelTypes
    {
    	Electric, Gassoline, Diesel
    }
    
    public sealed class Car : IEquatable<Car>
    {
    	private readonly Guid _Id;
    	private readonly string _Name;
    	private readonly bool _IsElectric;
    	private readonly FuelTypes _FuelType;
    
    	public Guid Id { get { return _Id; } }
    	public string Name { get { return _Name; } }
    	public bool IsElectric { get { return _IsElectric; } }
    	public FuelTypes FuelType { get { return _FuelType; } }
    
    	public Car(Guid Id, string Name, bool IsElectric, FuelTypes FuelType)
    	{
    		_Id = Id;
    		_Name = Name;
    		_IsElectric = IsElectric;
    		_FuelType = FuelType;
    	}
    
    	public override bool Equals(object obj)
    	{
    		if (obj is Car)
    			return Equals((Car)obj);
    		return false;
    	}
    
    	public bool Equals(Car obj)
    	{
    		if (obj == null) return false;
    		if (!EqualityComparer<Guid>.Default.Equals(_Id, obj._Id)) return false;
    		if (!EqualityComparer<string>.Default.Equals(_Name, obj._Name)) return false;
    		if (!EqualityComparer<bool>.Default.Equals(_IsElectric, obj._IsElectric)) return false;
    		if (!EqualityComparer<FuelTypes>.Default.Equals(_FuelType, obj._FuelType)) return false;
    		return true;
    	}
    
    	public override int GetHashCode()
    	{
    		int hash = 0;
    		hash ^= EqualityComparer<Guid>.Default.GetHashCode(_Id);
    		hash ^= EqualityComparer<string>.Default.GetHashCode(_Name);
    		hash ^= EqualityComparer<bool>.Default.GetHashCode(_IsElectric);
    		hash ^= EqualityComparer<FuelTypes>.Default.GetHashCode(_FuelType);
    		return hash;
    	}
    
    	public override string ToString()
    	{
    		return String.Format("{{ Id = {0}, Name = {1}, IsElectric = {2}, FuelType = {3} }}", _Id, _Name, _IsElectric, _FuelType);
    	}
    
    	public static bool operator ==(Car left, Car right)
    	{
    		if (object.ReferenceEquals(left, null))
    		{
    			return object.ReferenceEquals(right, null);
    		}
    
    		return left.Equals(right);
    	}
    
    	public static bool operator !=(Car left, Car right)
    	{
    		return !(left == right);
    	}
    }
