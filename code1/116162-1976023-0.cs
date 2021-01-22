    [DllImport("name.dll")]
    internal static extern int GetSweepParam(
    	int param_num,
    	[Out]byte[] param_name,
    	[Out]byte[] param_units,
    	double[] values,
    	byte[] error_string
    );
    
    static void Test()
    {
    	Encoding enc = Encoding.GetEncoding(437);
    	byte[] param_name = new byte[1000], param_units = new byte[1000];
    	GetSweepParam(123, param_name, param_units, new double[0], enc.GetBytes("input only"));
    	string name = enc.GetString(param_name, 0, Array.IndexOf(param_name, (byte)0));
    	string units = enc.GetString(param_units, 0, Array.IndexOf(param_units, (byte)0));
    }
