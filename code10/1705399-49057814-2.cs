	public class FlakeEntry2 : StackLayout
	{
		private Entry Entry;
		private Label ErrorLabel;
		public FlakeEntry2()
		{
			Entry = new Entry { };
			ErrorLabel = new Label
			{
				FontAttributes = FontAttributes.Italic,
				TextColor = Color.Red,
			};
			
			this.Entry.SetBinding(Entry.TextProperty, new Binding(nameof(EntryText), source: this));
			// You'll need to do the same to label's and other properties you need expose, but you get rid of the 'OnChanged' methods
			Children.Add(Entry);
			Children.Add(ErrorLabel);
		}
		#region Text property which I am trying to bind
		public static readonly BindableProperty EntryTextProperty = BindableProperty.Create(
													   propertyName: nameof(EntryText),
													   returnType: typeof(string),
													   declaringType: typeof(FlakeEntry2),
													   defaultValue: null,
													   defaultBindingMode: BindingMode.TwoWay);
		public string EntryText
		{
			get { return GetValue(EntryTextProperty)?.ToString(); }
			set { SetValue(EntryTextProperty, value); }
		}
		#endregion
	}
