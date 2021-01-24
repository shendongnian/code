	public class MyBoxText : Label /* It's bindable by inheritance */
	{
		// Added this as private property
		private ChangingPropagator changingPropagator;
        private ChangingPropagator ChangingPropagator
        {
            get
            {
                if (changingPropagator == null)
                    changingPropagator = new ChangingPropagator(this, OnPropertyChanged, nameof(Shadow.ShadowColor), nameof(Shadow.ShadowRadius));
                return changingPropagator;
            }
        }
		
		#region Properties
		public static readonly BindableProperty IsLoadingProperty = BindableProperty.Create(nameof(IsLoading), typeof(bool), typeof(MyBoxText), false) ;
		public bool IsLoading
		{
			get { return (bool)GetValue(IsLoadingProperty); }
			set { SetValue(IsLoadingProperty, value); }
		}
		public static readonly BindableProperty GhostProperty = BindableProperty.Create(nameof(Ghost), typeof(Shadow), typeof(MyBoxText), null) ;
		public Shadow Ghost
		{
			// Here I use the ChangingPropagator's Getter and Setter instead of the deafult ones:
			get { return ChangingPropagator.GetValue<Shadow>(GhostProperty); }
			set { ChangingPropagator.SetValue(GhostProperty,ref value); }
		}
		#endregion
	}
