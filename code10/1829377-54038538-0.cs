    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public interface IOption
    {
    	string Name { get; set; }
    }
    public class ExitOption : IOption
    {
    	public ExitOption(string name) => Name = name;
    	public string Name { get; set; }
    }
    public abstract class Option : IOption
    {
    	public Option(string name) => Name = name;
    	public string Name { get; set; }
    	public abstract object ObjValue { get; set; }
      public abstract IEnumerable<object> ObjValues { get;}
    }
    public class Option<T> : Option
    {
    	private T _value;
    	private List<T> _values;
    
    	public Option(string name, T initialValue, params T[] values) : base(name)
    	{
    		(_value, _values) = (initialValue, values.ToList());
    	}
    	public override IEnumerable<object> ObjValues { get => _values.Cast<object>().AsEnumerable(); }
    	public T Value { get => _value; set => _value = value; }
    	public override object ObjValue { get => _value; set => _value = (T)value; }
    	public IEnumerable<T> Values => _values.AsEnumerable();
    }
