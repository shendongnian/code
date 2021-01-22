    public class PropertyChangedActie : Actie
	{
		public PropertyChangedActie(Vorm[] Vormen, string PropertyName, object OldValue, object NewValue)
			: base(Vormen)
		{
			propertyName = PropertyName;
			oldValue = OldValue;
			newValue = NewValue;
		}
		private object oldValue;
		public object OldValue
		{
			get { return oldValue; }
		}
		private object newValue;
		public object NewValue
		{
			get { return newValue; }
		}
		private string propertyName;
		public string PropertyName
		{
			get { return propertyName; }
		}
		public override void Undo()
		{
			//Type t = base.Vorm.GetType();
			PropertyInfo info = Vormen.First().GetType().GetProperty(propertyName);
			foreach(Vorm v in Vormen)
			{
				v.CanRaiseVeranderdEvent = false;
				info.SetValue(v, oldValue, null);
				v.CanRaiseVeranderdEvent = true;
			}
		}
		public override void Redo()
		{
			//Type t = base.Vorm.GetType();
			PropertyInfo info = Vormen.First().GetType().GetProperty(propertyName);
			foreach(Vorm v in Vormen)
			{
				v.CanRaiseVeranderdEvent = false;
				info.SetValue(v, newValue, null);
				v.CanRaiseVeranderdEvent = true;
			}
		}
	}
