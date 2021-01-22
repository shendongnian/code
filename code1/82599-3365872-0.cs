   	Point pBaseLoc = new Point(40, 40)
	int x = -500, y = 140;
	Point pLoc = new Point(x, y);
	bool bIsInsideBounds = false;
	foreach (Screen s in Screen.AllScreens)
	{
		bIsInsideBounds = s.Bounds.Contains(pLoc);
		if (bIsInsideBounds) { break; }
	}//foreach (Screen s in Screen.AllScreens)
	if (!bIsInsideBounds) { pLoc = pBaseLoc;  }
	this.Location = pLoc;
