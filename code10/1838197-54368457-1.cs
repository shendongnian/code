	public void InitSensorService()
	{
		sManager = Application.Context.GetSystemService(Context.SensorService) as SensorManager;
		sManager.RegisterListener(this, sManager.GetDefaultSensor(SensorType.StepCounter), SensorDelay.Normal);
	}
