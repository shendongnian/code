    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var entity = new Entity();
    			entity.PropertyChanged += new SerializableHandler().PropertyChanged;
    			entity.PropertyChanged += new NonSerializableHandler().PropertyChanged;
    
    			Console.WriteLine("Before serialization:");
    			entity.Name = "Someone";
    
    			using (var memoryStream = new MemoryStream())
    			{
    				var binaryFormatter = new BinaryFormatter();
    				binaryFormatter.Serialize(memoryStream, entity);
    				memoryStream.Position = 0;
    				entity = binaryFormatter.Deserialize(memoryStream) as Entity;
    			}
    
    			Console.WriteLine();
    			Console.WriteLine("After serialization:");
    			entity.Name = "Kent";
    
    			Console.WriteLine();
    			Console.WriteLine("Done - press any key");
    			Console.ReadKey();
    		}
    
    		[Serializable]
    		private class SerializableHandler
    		{
    			public void PropertyChanged(object sender, PropertyChangedEventArgs e)
    			{
    				Console.WriteLine("  Serializable handler called");
    			}
    		}
    
    		private class NonSerializableHandler
    		{
    			public void PropertyChanged(object sender, PropertyChangedEventArgs e)
    			{
    				Console.WriteLine("  Non-serializable handler called");
    			}
    		}
    	}
    
    	[Serializable]
    	public class Entity : INotifyPropertyChanged
    	{
    		private string _name;
    		private readonly List<Delegate> _serializableDelegates;
    
    		public Entity()
    		{
    			_serializableDelegates = new List<Delegate>();
    		}
    
    		public string Name
    		{
    			get { return _name; }
    			set
    			{
    				if (_name != value)
    				{
    					_name = value;
    					OnPropertyChanged("Name");
    				}
    			}
    		}
    
    		[field:NonSerialized]
    		public event PropertyChangedEventHandler PropertyChanged;
    
    		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
    		{
    			var handler = PropertyChanged;
    
    			if (handler != null)
    			{
    				handler(this, e);
    			}
    		}
    
    		protected void OnPropertyChanged(string propertyName)
    		{
    			OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
    		}
    
    		[OnSerializing]
    		public void OnSerializing(StreamingContext context)
    		{
    			_serializableDelegates.Clear();
    			var handler = PropertyChanged;
    
    			if (handler != null)
    			{
    				foreach (var invocation in handler.GetInvocationList())
    				{
    					if (invocation.Target.GetType().IsSerializable)
    					{
    						_serializableDelegates.Add(invocation);
    					}
    				}
    			}
    		}
    
    		[OnDeserialized]
    		public void OnDeserialized(StreamingContext context)
    		{
    			foreach (var invocation in _serializableDelegates)
    			{
    				PropertyChanged += (PropertyChangedEventHandler)invocation;
    			}
    		}
    	}
    }
