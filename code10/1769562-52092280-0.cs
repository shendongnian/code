	/* globals */
	ModelVisual3D model; // initialized and model file loaded
	Transform3DGroup tg = new Transform3DGroup();
	private async void TimerEvent() 
	{
		RotateTransform3D rot = new RotateTransform3D();
		QuaternionRotation3D q = new QuaternionRotation3D();
			
		double x = 0, y = 0, z = 0;
		List<Reading> results = await Device.ReadSensor();
		
		
		foreach (Reading r in results)
		{
			switch (r.Type)
			{
				case "RPF_SEN_ACCELX":
					x = r.Value;
					break;
				case "RPF_SEN_ACCELY":
					y = r.Value;
					break;
				case "RPF_SEN_ACCELZ":
					z = r.Value;
					angle = GetAngle(x, y).ToDegrees();
					q.Quaternion = new Quaternion(new Vector3D(0, 0, 1), angle);
					break;
			}
			
			rot.Rotation = q;
			
			tg.Children.Clear();
			tg.Children.Add(rot);
			
			model.Transform = tg; // Use Transform3DGroup!
		}
	}
