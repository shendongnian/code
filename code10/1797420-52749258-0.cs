    int diffCounter = 0;
    double xOne = 0;
    double xTwo = 0;
       
    private void chart1_MouseClick(object sender, MouseEventArgs e)
    {
        HitTestResult result = chart1.HitTest(e.X, e.Y);
        if (result.PointIndex >= 0)
        {
            if (diffCounter == 0)
            {
                xOne = result.Series.Points[result.PointIndex].XValue;
                diffCounter++;
                Console.WriteLine("VALX 2 " + xOne  );
            }
            else if (diffCounter == 1)
            {
                xTwo = result.Series.Points[result.PointIndex].XValue;
                diffCounter = 0;
                Console.WriteLine("VALX 1 " + xTwo  );
            }
            Console.WriteLine("Delta = " +( xTwo - xOne) );
        }
    }
