	public const int NVCPL_API_NUMBER_OF_GPUS =7;    // Graphics card number of GPUs. 
	public const int NVCPL_API_NUMBER_OF_SLI_GPUS = 8;    // Graphics card number of SLI GPU clusters available. 
	public const int NVCPL_API_SLI_MULTI_GPU_RENDERING_MODE = 9;    // Get/Set SLI multi-GPU redering mode.  
	
	[DllImport("NVCPL.DLL", CallingConvention=CallingConvention.Cdecl)]
	public static extern bool nvCplGetDataInt([In] int lFlag, [Out] out int plInfo);
	
	public static void Main() 	{
		int sliGpuCount;
		if (nvCplGetDataInt(NVCPL_API_NUMBER_OF_SLI_GPUS, out sliGpuCount)) {
			// we got the result
			Console.WriteLine(string.Format("SLI GPU present: {0}", sliGpuCount));
		} else {
			// something did go wrong
			Console.WriteLine("Failed to query NV data");
		}
	}
