    public partial class CustomSwitch : ContentView
	{
		#region Properties
		public static BindableProperty OutlineColorProperty = BindableProperty.Create("OutlineColor", typeof(Color), typeof(Color), Color.LightGray);
		public static BindableProperty SwitchBackgroundColorProperty = BindableProperty.Create("SwitchBackgroundColor", typeof(Color), typeof(Color), Color.White);
		public static BindableProperty SwitchBackgroundColorToggledProperty = BindableProperty.Create("SwitchBackgroundColorToggled", typeof(Color), typeof(Color), Color.Green);
		public static BindableProperty ButtonFillColorProperty = BindableProperty.Create("ButtonFillColor", typeof(Color), typeof(Color), Color.White);
		public static BindableProperty IsToggledProperty = BindableProperty.Create("IsToggled", typeof(bool), typeof(bool), false);
		public Color OutlineColor
		{
			get { return (Color)GetValue(OutlineColorProperty); }
			set { SetValue(OutlineColorProperty, value); }
		}
		public Color ToggledBackgroundColor
		{
			get { return (Color)GetValue(SwitchBackgroundColorToggledProperty); }
			set { SetValue(SwitchBackgroundColorToggledProperty, value); }
		}
		public Color SwitchBackgroundColor
		{
			get { return (Color)GetValue(SwitchBackgroundColorProperty); }
			set { SetValue(SwitchBackgroundColorProperty, value); }
		}
		public Color ButtonFillColor
		{
			get { return (Color)GetValue(ButtonFillColorProperty); }
			set { SetValue(ButtonFillColorProperty, value); }
		}
		public bool IsToggled
		{
			get { return (bool)GetValue(IsToggledProperty); }
			set {
				SetValue(IsToggledProperty, value);
				OnToggleChange?.Invoke(this, value);
			}
		}
		#endregion
		public CustomSwitch()
		{
			InitializeComponent();
		}
		public event EventHandler<bool> OnToggleChange;
		private SKColor? animatedBgColor = null;
		private SKPoint buttonPosition = new SKPoint(30, 30);
		private bool isAnimating = false;
		protected virtual void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
		{
			SKImageInfo info = e.Info;
			SKSurface surface = e.Surface;
			SKCanvas canvas = surface.Canvas;
			canvas.Clear();
			SKPaint primaryFill = new SKPaint
			{
				Style = SKPaintStyle.Fill,
				Color = animatedBgColor != null ? animatedBgColor.Value : IsToggled ? ToggledBackgroundColor.ToSKColor() : SwitchBackgroundColor.ToSKColor(),
				IsAntialias = true
			};
			SKPaint primaryOutline = new SKPaint
			{
				Style = SKPaintStyle.Stroke,
				StrokeWidth = 2,
				Color = OutlineColor.ToSKColor(),
				IsAntialias = true
			};
			SKPaint circleFill = new SKPaint
			{
				Style = SKPaintStyle.Fill,
				Color = ButtonFillColor.ToSKColor(),
				IsAntialias = true
			};
			SKPaint circleOutline = new SKPaint
			{
				Style = SKPaintStyle.Stroke,
				StrokeWidth = 2,
				Color = OutlineColor.ToSKColor(),
				IsAntialias = true
			};
			SKRoundRect rect = new SKRoundRect(new SKRect(0, 0, 120, 60), 30, 30);
			SKRoundRect rectOutline = new SKRoundRect(new SKRect(1, 1, 119, 59), 28, 28);
			if (!isAnimating)
				buttonPosition.X = IsToggled ? 90f : 30f;
			canvas.DrawRoundRect(rect, primaryFill);
			canvas.DrawRoundRect(rectOutline, primaryOutline);
			canvas.DrawCircle(buttonPosition, 24, circleFill);
			canvas.DrawCircle(buttonPosition, 23, circleOutline);
		}
		private void AnimateToToggle()
		{
			isAnimating = true;
			new Animation((value) =>
			{
				double colorPartWeight = 1 - value;
				animatedBgColor = SkiaTools.CalculateWeightedColor(SwitchBackgroundColor, ToggledBackgroundColor, colorPartWeight, value);
				PrimaryCanvas.InvalidateSurface();
			}).Commit(this, "bgcolorAnimation", length: (uint)250, repeat: () => false);
			new Animation((value) =>
			{
				buttonPosition.X = 30 + (float)(value * 60.0);
			}).Commit(this, "positionAnimation", length: (uint)250, repeat: () => false, finished: (v,c) => { buttonPosition.X = 90.0f; isAnimating = false; });
		}
		private void AnimateFromToggle()
		{
			isAnimating = true;
			new Animation((value) =>
			{
				double colorPartWeight = 1 - value;
				animatedBgColor = SkiaTools.CalculateWeightedColor(ToggledBackgroundColor, SwitchBackgroundColor, colorPartWeight, value);
				PrimaryCanvas.InvalidateSurface();
			}).Commit(this, "bgcolorAnimation", length: (uint)250, repeat: () => false);
			new Animation((value) =>
			{
				buttonPosition.X = 90 - (float)(value * 60.0);
			}).Commit(this, "positionAnimation", length: (uint)250, repeat: () => false, finished: (v, c) => { buttonPosition.X = 30.0f; isAnimating = false; });
		}
		private void OnElementTapped(object sender, EventArgs e)
		{
			IsToggled = !IsToggled;
			if (IsToggled == true)
				AnimateToToggle();
			else
				AnimateFromToggle();
		}
	}
