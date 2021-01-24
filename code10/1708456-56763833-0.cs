    string DatafromCOM;
            double[] x = new double[100];
            double[] y = new double[100];
            int i;
            PointPairList listPointsOne = new PointPairList();
     private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
            {
                try
                {
                    while (serialPort1.BytesToRead > 0)
                    {
                        DatafromCOM = serialPort1.ReadLine();
                        double iData;
                        var ok = double.TryParse(txtKQ.Text, out iData);
                        if (DatafromCOM.Trim() != "" && ok)
                        {
                            i= (i + 1) % 100;
                            x[i] = i;
                            y[i] = iData;
                            listPointsOne.Add(i,iData);
    
                        }
                        z1.GraphPane.CurveList.Clear(); // Change here
                    }
    
                }
                catch { }
            }
 
    private void timer1_Tick(object sender, EventArgs e)
        {
               
                z1.GraphPane.AddCurve(null, listPointsOne, Color.Red, SymbolType.None);
                z1.AxisChange();
                z1.Invalidate();
        }
