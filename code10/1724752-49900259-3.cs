    private void InitializeChart()
    		{
    			tChart1.Aspect.View3D = false;
    
    			tChart1.Dock = DockStyle.Fill;
    			Steema.TeeChart.Styles.Line line1 = new Steema.TeeChart.Styles.Line(tChart1.Chart);
    			rnd = new Random();
    			for (int i = 0; i < 10; i++)
    			{
    				line1.Add(i * 10, i); //points without labels
    			}
    
    			//tChart1.GetAxisLabel += TChart1_GetAxisLabel;
    			tChart1.Axes.Bottom.Labels.Items.Clear();
    			for (int i = 0; i < line1.Count; ++i)
    			{
    				tChart1.Axes.Bottom.Labels.Items.Add(line1.XValues[i], ((char)(64 + i)).ToString());
    			}
    
    
    		}
