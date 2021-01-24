	void OrientationSensor_ReadingChanged(object sender, OrientationSensorChangedEventArgs e)
	{
		if (originQ == Quaternion.Identity) // auto-origin on first sample or when requested
		{
			originQ = Quaternion.Inverse(e.Reading.Orientation);
		}
		var q = Quaternion.Multiply(originQ, e.Reading.Orientation);
		GetEulerAngles(q, out yaw, out pitch, out roll); // assuming "right-hand" orientation
		SmoothAndThrottle(yaw, pitch, roll, () =>
		{
			Device.BeginInvokeOnMainThread(() =>
			{
				pitchLabel.Text = pitch.ToString();
				rollLabel.Text = roll.ToString();
				yawLabel.Text = yaw.ToString();
                // This will appear to keep the image aligned to the origin/centre.
				direction.RotateTo(90 * yaw, 1);
				direction.RotationX = 90 * pitch;
				direction.RotationY = -90 * roll;
			});
		});
	}
