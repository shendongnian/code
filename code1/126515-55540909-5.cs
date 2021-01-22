    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace Logger
    {
    	public partial class LoggerExample : Form
    	{
    		private Logger _log = new Logger(100u);
    		private List<Color> _randomColors = new List<Color> { Color.Red, Color.SkyBlue, Color.Green };
    		private Random _r = new Random((int)DateTime.Now.Ticks);
    
    		public LoggerExample()
    		{
    			InitializeComponent();
    		}
    
    		private void timerGenerateText_Tick(object sender, EventArgs e)
    		{
    			if (_r.Next(10) > 5)
    				_log.AddToLog("Some event to log.", _randomColors[_r.Next(3)]);
    		}
    
    		private void timeUpdateLogWindow_Tick(object sender, EventArgs e)
    		{
    			richTextBox1.Rtf = _log.GetLogAsRichText(true);
    			richTextBox1.ScrollToBottom();
    		}
    	}
    }
