    public Guideline GetSnapGuide(Point hitPoint)
		{
			foreach (Guideline gl in Guides)
			{
				if (!gl.IsDisplayed) continue;
				if (gl.Info.IsSnap && !gl.Info.IsMoving)
					if (gl.IsOnGuide(hitPoint, _Container.dPicCapture))
					{
						return gl;
					}
			}
			return null;
		}
