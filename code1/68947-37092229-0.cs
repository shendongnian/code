		public void setHueRotate(Bitmap bmpElement, float value) {
			const float wedge = 120f / 360;
			
			var hueDegree = -value % 1;
			if (hueDegree < 0) hueDegree += 1;
			var matrix = new float[5][];
			if (hueDegree <= wedge)
			{
				//Red..Green
				var theta = hueDegree / wedge * (Math.PI / 2);
				var c = (float)Math.Cos(theta);
				var s = (float)Math.Sin(theta);
				matrix[0] = new float[] { c, 0, s, 0, 0 };
				matrix[1] = new float[] { s, c, 0, 0, 0 };
				matrix[2] = new float[] { 0, s, c, 0, 0 };
				matrix[3] = new float[] { 0, 0, 0, 1, 0 };
				matrix[4] = new float[] { 0, 0, 0, 0, 1 };
				
			} else if (hueDegree <= wedge * 2)
			{
				//Green..Blue
				var theta = (hueDegree - wedge) / wedge * (Math.PI / 2);
				var c = (float) Math.Cos(theta);
				var s = (float) Math.Sin(theta);
				matrix[0] = new float[] {0, s, c, 0, 0};
				matrix[1] = new float[] {c, 0, s, 0, 0};
				matrix[2] = new float[] {s, c, 0, 0, 0};
				matrix[3] = new float[] {0, 0, 0, 1, 0};
				matrix[4] = new float[] {0, 0, 0, 0, 1};
			}
			else
			{
				//Blue..Red
				var theta = (hueDegree - 2 * wedge) / wedge * (Math.PI / 2);
				var c = (float)Math.Cos(theta);
				var s = (float)Math.Sin(theta);
				matrix[0] = new float[] {s, c, 0, 0, 0};
				matrix[1] = new float[] {0, s, c, 0, 0};
				matrix[2] = new float[] {c, 0, s, 0, 0};
				matrix[3] = new float[] {0, 0, 0, 1, 0};
				matrix[4] = new float[] {0, 0, 0, 0, 1};
			}
			
			Bitmap originalImage = bmpElement;
			var imageAttributes = new ImageAttributes();
			imageAttributes.ClearColorMatrix();
			imageAttributes.SetColorMatrix(new ColorMatrix(matrix), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
			grpElement.DrawImage(
				originalImage, elementArea,
				0, 0, originalImage.Width, originalImage.Height,
				GraphicsUnit.Pixel, imageAttributes
				);
		}
