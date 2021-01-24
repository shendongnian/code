    	public abstract class Setting {
		public abstract Type keyType { get; }
		public string Key { get; protected set; }
		public object value { get; protected set; }
		protected abstract Action writer { get; }
		public void Write() => writer();
	}
	public class Setting<T> : Setting {
		public override Type keyType => typeof(T);
		protected override Action writer => () => typeWriter(Value);
		public string Section { get; set; }
		public T Value {get; set;}
		private Action<T> typeWriter { get; }
		
		public Setting(string section, string key, T value, Action<T> writer) {
			Section = section;
			Key = key;
			this.value = Value = value;
			typeWriter = writer;
		}
	}
	public class Usage {
		private List<Setting> settings = new List<Setting>() {
			new Setting<double>("", "x", 10, n => Debug.WriteLine(n % 4)),
			new Setting<string>("", "y", "abc", s => Debug.WriteLine(s.ToUpper())),
			new Setting<bool>("", "z", true, b => Debug.Write(!b)),
		};
		public Usage() {
			foreach (var s in settings) {
				Debug.Write($"{s.keyType.Name} {s.Key} =");
				s.Write();
			}
		}
	}
