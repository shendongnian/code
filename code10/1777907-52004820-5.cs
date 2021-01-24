    public class AnimalFacotry {
    	Dictionary<AnimalType, Animal> _dict;
    	public AnimalFacotry() {
    		_dict = new Dictionary<AnimalType, Animal>();
    		_dict.Add(AnimalType.PIG, new Pig());
    		_dict.Add(AnimalType.Chicken, new Chicken());
    		_dict.Add(AnimalType.Cow, new Cow());
    	}
    	public Animal Spawn(AnimalType type)
    	{
    		if (_dict.ContainsKey(type))
    		{
    			return _dict[type];
    		}
    		return null;
    	}
    }
