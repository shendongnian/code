    private void AddDataToGraph(ZedGraphControl zg1, XDate xValue, double yValue1, double yValue2)
        {
            // Make sure that the curvelist has at least one curve
            if (zg1.GraphPane.CurveList.Count <= 0)
                return;
            // Get the first CurveItem in the graph
            LineItem curve = zg1.GraphPane.CurveList[0] as LineItem;
            LineItem curve2 = zg1.GraphPane.CurveList[1] as LineItem;
           
            if (curve == null || curve2 == null)
                return;
            // Get the PointPairList
            IPointListEdit list = curve.Points as IPointListEdit;
            IPointListEdit list2 = curve2.Points as IPointListEdit;
            // If this is null, it means the reference at curve.Points does not
            // support IPointListEdit, so we won't be able to modify it
            if (list == null || list2 == null)
                return;
            // add new data points to the graph
            list.Add(xValue, yValue1);
			list2.Add(xValue, yValue2);
            
            // force redraw
            zg1.Invalidate();
        }
