    public class NativeImage : Image
	{
		public static readonly BindableProperty CommandProperty =
			BindableProperty.Create(
				nameof(Command),
				typeof(ICommand),
				typeof(NativeImage),
				default(ICommand));
		public ICommand Command
		{
			get => (ICommand) GetValue(CommandProperty);
			set => SetValue(CommandProperty, value);
		}
		public static readonly BindableProperty CommandParameterProperty =
			BindableProperty.Create(
				nameof(Command),
				typeof(object),
				typeof(NativeImage));
		public object CommandParameter
		{
			get => GetValue(CommandParameterProperty);
			set => SetValue(CommandParameterProperty, value);
		}
		private ICommand TransitionCommand
		{
			get
			{
				return new Command(async () =>
				{
					AnchorX = 0.48;
					AnchorY = 0.48;
					await this.ScaleTo(0.8, 50, Easing.Linear);
					await Task.Delay(100);
					await this.ScaleTo(1, 50, Easing.Linear);
					Command?.Execute(CommandParameter);
				});
			}
		}
		public NativeImage()
		{
			Initialize();
		}
		public void Initialize()
		{
			GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = TransitionCommand
			});
		}
	}
