       public bool inPoly(int x, int y)
        {
            int i, j = hull.Count - 1;
            var oddNodes = false;
            for (i = 0; i < hull.Count; i++)
            {
                if (hull[i].Y < y && hull[j].Y >= y
                    || hull[j].Y < y && hull[i].Y >= y)
                {
                    var delta = (hull[j].X - hull[i].X);
                    if (delta == 0)
                    {
                        if (0 < x) oddNodes = !oddNodes;
                    }
                    else if (hull[i].X + (y - hull[i].X) / delta * delta < x)
                    {
                        oddNodes = !oddNodes;
                    }
                }
                j = i;
            }
            return oddNodes;
        }
