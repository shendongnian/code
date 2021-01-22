        private void AddDataToGraph(ZedGraphControl zg1, XDate xValue, double[] yValues)
        {
            GraphPane myPane = zg1.GraphPane;
            // Make sure that the curvelist has at least one curve
            if (myPane.CurveList.Count <= 0)
                return;
            else if (myPane.CurveList.Count != yValues.Length)
                return;
            for (int i = 0; i < yValues.Length; i++ )
            {
                ((IPointListEdit)myPane.CurveList[i].Points).Add(xValue, yValues[i]);
            }
            // force redraw
            zg1.Invalidate();
        }
