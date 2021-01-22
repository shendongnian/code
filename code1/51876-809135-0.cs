        public bool EnableScheduleB
		{
			get
			{
				return _btnScheduleB.Enabled;
			}
			set
			{
				_btnScheduleB.Enabled = value;
			}
		}
		public DepositFrequency DepositorFrequency
		{
			get
			{
				return (DepositFrequency)_uosDepositorFrequency.Value;
			}
			set
			{
				_uosDepositorFrequency.Value = (int)value;
			}
		}
