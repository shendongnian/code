    public partial class PollingIntervalGroupBox : GroupBox
    {
    	private const int DAYS_IN_WEEK = 7;
    	private const int MINUTES_IN_HOUR = 60;
    	private const int HOURS_IN_DAY = 24;
    	private const int MINUTES_IN_DAY = MINUTES_IN_HOUR * HOURS_IN_DAY;
    	private const int MAX_TOTAL_DAYS = 100;
    
    	private static readonly decimal MIN_TOTAL_NUM_MINUTES = 1; // Anything faster than once per minute can bog down our servers.
    	private static readonly decimal MAX_TOTAL_NUM_MINUTES = (MAX_TOTAL_DAYS * MINUTES_IN_DAY) - 1; // 99 days should be plenty.
    	// The value above was chosen so to not cause an overflow exception.
    	// Watch out for it - numericUpDownControls each have a MaximumValue setting.
    	private bool _totalMinutesChanging;
    
    	public PollingIntervalGroupBox()
    	{
    		InitializeComponent();
    		InitializeComponentCustom();
    	}
    
    	private void InitializeComponentCustom()
    	{
    		this.m_upDownDays.Maximum = MAX_TOTAL_DAYS - 1;
    		this.m_upDownHours.Maximum = HOURS_IN_DAY - 1;
    		this.m_upDownMinutes.Maximum = MINUTES_IN_HOUR - 1;
    		this.m_upDownTotalMinutes.Maximum = MAX_TOTAL_NUM_MINUTES;
    		this.m_upDownTotalMinutes.Minimum = MIN_TOTAL_NUM_MINUTES;
    
    		this.m_upDownTotalMinutes.ValueChanged += this.m_upDownTotalMinutes_ValueChanged;
    		this.m_upDownDays.ValueChanged += this.m_upDownDays_ValueChanged;
    		this.m_upDownHours.ValueChanged += this.m_upDownHours_ValueChanged;
    		this.m_upDownMinutes.ValueChanged += this.m_upDownMinutes_ValueChanged;
    	}
    
    	private void m_upDownTotalMinutes_ValueChanged(object sender, EventArgs e)
    	{
    		setTotalMinutes(this.m_upDownTotalMinutes.Value);
    	}
    
    	private void m_upDownDays_ValueChanged(object sender, EventArgs e)
    	{
    		updateTotalMinutes();
    	}
    
    	private void m_upDownHours_ValueChanged(object sender, EventArgs e)
    	{
    		updateTotalMinutes();
    	}
    
    	private void m_upDownMinutes_ValueChanged(object sender, EventArgs e)
    	{
    		updateTotalMinutes();
    	}
    
    	private void updateTotalMinutes()
    	{
    		this.setTotalMinutes(
    			MINUTES_IN_DAY * m_upDownDays.Value +
    			MINUTES_IN_HOUR * m_upDownHours.Value +
    			m_upDownMinutes.Value);
    	}
    
    	public decimal TotalMinutes { get { return m_upDownTotalMinutes.Value; } set { m_upDownTotalMinutes.Value = value; } }
    
    	public decimal TotalHours { set { setTotalMinutes(value * MINUTES_IN_HOUR); } }
    
    	public decimal TotalDays { set { setTotalMinutes(value * MINUTES_IN_DAY); } }
    
    	public decimal TotalWeeks { set { setTotalMinutes(value * DAYS_IN_WEEK * MINUTES_IN_DAY); } }
    
    	private void setTotalMinutes(decimal totalMinutes)
    	{
    		if (_totalMinutesChanging) return;
    		try
    		{
    			_totalMinutesChanging = true;
    			decimal nTotalMinutes = totalMinutes;
    			if (totalMinutes < MIN_TOTAL_NUM_MINUTES)
    			{
    				nTotalMinutes = MIN_TOTAL_NUM_MINUTES;
    			}
    			if (totalMinutes > MAX_TOTAL_NUM_MINUTES)
    			{
    				nTotalMinutes = MAX_TOTAL_NUM_MINUTES;
    			}
    			// First set the total minutes
    			this.m_upDownTotalMinutes.Value = nTotalMinutes;
    
    			// Then set the rest
    			this.m_upDownDays.Value = (int)(nTotalMinutes / MINUTES_IN_DAY);
    			nTotalMinutes = nTotalMinutes % MINUTES_IN_DAY; // variable reuse.
    			this.m_upDownHours.Value = (int)(nTotalMinutes / MINUTES_IN_HOUR);
    			nTotalMinutes = nTotalMinutes % MINUTES_IN_HOUR;
    			this.m_upDownMinutes.Value = nTotalMinutes;
    		}
    		finally
    		{
    			_totalMinutesChanging = false;
    		}
    	}
    }
