		public static Context context;
		protected override void OnResume()
		{
			context = this;
			base.OnResume();
		}
