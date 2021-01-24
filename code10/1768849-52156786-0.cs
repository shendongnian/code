    public class HistogramWindow : Content
    {
        #region Windows form designer generated code
        //.... ... ...
        #endregion        
        #region gather stats
        //... ... ...
        #endregion
        private static Color[] colors = new Color[] 
        {
			Color.FromArgb(192, 0, 0),
			Color.FromArgb(0, 192, 0),
			Color.FromArgb(0, 0, 192),
			Color.FromArgb(128, 128, 128),
		};
        private int currentImageHash = 0;
        private ImageStatistics stat;
        private AForge.Controls.Histogram histogram;
        private AForge.Math.Histogram activeHistogram = null;
        public HistogramWindow()
        {
            InitializeComponent();
        }
        // selection changed in channels combo
        private void channelCombo_SelectedIndexChanged( object sender, System.EventArgs e )
        {
            if ( stat != null )
            {
                SwitchChannel( ( stat.IsGrayscale ) ? 3 : channelCombo.SelectedIndex );
            }
        }
        // Switch channel
        public void SwitchChannel( int channel )
        {
            if ( ( channel >= 0 ) && ( channel <= 2 ) )
            {
                if ( !stat.IsGrayscale )
                {
                    histogram.Color = colors[channel];
                    activeHistogram = ( channel == 0 ) ? stat.Red : ( channel == 1 ) ? stat.Green : stat.Blue;
                }
            }
            else if ( channel == 3 )
            {
                if ( stat.IsGrayscale )
                {
                    histogram.Color = colors[3];
                    activeHistogram = stat.Gray;
                }
            }
            if ( activeHistogram != null )
            {
                histogram.Values = activeHistogram.Values;
                meanLabel.Text = activeHistogram.Mean.ToString( "F2" );
                stdDevLabel.Text = activeHistogram.StdDev.ToString( "F2" );
                medianLabel.Text = activeHistogram.Median.ToString( );
                minLabel.Text = activeHistogram.Min.ToString( );
                maxLabel.Text = activeHistogram.Max.ToString( );
            }
        }
        // Cursor position changed over the hostogram
        private void histogram_PositionChanged( object sender, AForge.Controls.HistogramEventArgs e )
        {
            int pos = e.Position;
            if ( pos != -1 )
            {
                levelLabel.Text = pos.ToString( );
                countLabel.Text = activeHistogram.Values[pos].ToString( );
                percentileLabel.Text = ( (float) activeHistogram.Values[pos] * 100 / stat.PixelsCount ).ToString( "F2" );
            }
            else
            {
                levelLabel.Text = "";
                countLabel.Text = "";
                percentileLabel.Text = "";
            }
        }
        // Selection changed in the hostogram
        private void histogram_SelectionChanged( object sender, AForge.Controls.HistogramEventArgs e )
        {
            int min = e.Min;
            int max = e.Max;
            int count = 0;
            levelLabel.Text = min.ToString( ) + "..." + max.ToString( );
            // count pixels
            for ( int i = min; i <= max; i++ )
            {
                count += activeHistogram.Values[i];
            }
            countLabel.Text = count.ToString( );
            percentileLabel.Text = ( (float) count * 100 / stat.PixelsCount ).ToString( "F2" );
        }
        // On "Log" check - switch mode
        private void logCheck_CheckedChanged( object sender, System.EventArgs e )
        {
            histogram.IsLogarithmicView = logCheck.Checked;
        }
    }
