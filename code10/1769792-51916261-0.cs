    static void testFEAST() {
    Console.WriteLine("FEAST");
    var B = new double[,] 
    {
	     { 13.3733 , 2.4521 , 3.3799 , 3.1977 , 2.9007 , 2.6071 , 3.3902 , 3.2255 , 2.9586 , 3.5153 } ,
		 { 2.4521 , 12.1223 , 2.5726 , 2.2380 , 2.0391 , 2.1209 , 2.7328 , 2.3948 , 2.2053 , 2.7973 } ,
		 { 3.3799 , 2.5726 , 13.7485 , 3.1880 , 2.8773 , 2.7257 , 3.5214 , 3.3768 , 3.1508 , 3.5774 } ,
		 { 3.1977 , 2.2380 , 3.1880 , 14.1512 , 2.7701 , 2.7678 , 3.6396 , 3.5524 , 2.8490 , 3.8841 } ,
		 { 2.9007 , 2.0391 , 2.8773 , 2.7701 , 12.9673 , 2.3737 , 2.8522 , 2.8937 , 2.4185 , 3.0515 },
		 { 2.6071 , 2.1209 , 2.7257 , 2.7678 , 2.3737 , 12.6557 , 3.2495 , 2.7260 , 2.3528 , 2.9746 } ,
		 { 3.3902 , 2.7328 , 3.5214 , 3.6396 , 2.8522 , 3.2495 , 14.3296 , 3.6048 , 3.1249 , 3.9598 } ,
		 { 3.2255 , 2.3948 , 3.3768 , 3.5524 , 2.8937 , 2.7260 , 3.6048 , 13.5041 , 2.8991 , 3.7164 } ,
		 { 2.9586 , 2.2053 , 3.1508 , 2.8490 , 2.4185 , 2.3528 , 3.1249 , 2.8991 , 12.7476 , 3.1122 } ,
		 { 3.5153 , 2.7973 , 3.5774 , 3.8841 , 3.0515 , 2.9746 , 3.9598 , 3.7164 , 3.1122 , 14.3441 }
    };
    var A = new double[,]
    {
         { 11.5799 , 1.7403 , 2.0762 , 2.1079 , 1.7030 , 1.5895 , 2.1214 , 2.2385 , 2.1249 , 1.8184 },
		 { 1.7403 , 12.4871 , 3.0054 , 2.7232 , 2.3889 , 1.8735 , 2.7554 , 2.7438 , 2.7967 , 2.4238 },
		 { 2.0762 , 3.0054 , 14.0486 , 3.4330 , 2.8362 , 2.5154 , 3.5907 , 3.1904 , 3.6474 , 3.0380 },
		 { 2.1079 , 2.7232 , 3.4330 , 13.4159 , 2.6667 , 2.4686 , 3.3515 , 3.1004 , 3.3094 , 2.7956 },
		 { 1.7030 , 2.3889 , 2.8362 , 2.6667 , 12.6734 , 1.6063 , 2.9022 , 2.6043 , 2.7512 , 2.3908 },
		 { 1.5895 , 1.8735 , 2.5154 , 2.4686 , 1.6063 , 12.3309 , 2.4514 , 2.3327 , 2.5532 , 1.8412 },
		 { 2.1214 , 2.7554 , 3.5907 , 3.3515 , 2.9022 , 2.4514 , 13.6878 , 3.0864 , 3.3708 , 2.8628 },
		 { 2.2385 , 2.7438 , 3.1904 , 3.1004 , 2.6043 , 2.3327 , 3.0864 , 13.6752 , 3.2175 , 3.0414 },
		 { 2.1249 , 2.7967 , 3.6474 , 3.3094 , 2.7512 , 2.5532 , 3.3708 , 3.2175 , 13.8028 , 2.7187 },
		 { 1.8184 , 2.4238 , 3.0380 , 2.7956 , 2.3908 , 1.8412 , 2.8628 , 3.0414 , 2.7187 , 12.9621}
    }; 
	    
    var fpm = new int[64];
    fpm[0] = 1;  fpm[1] = 8;  fpm[2] = 12; fpm[3] = 20;  fpm[4] = 0;
    fpm[5] = 0; fpm[13] = 0;  fpm[26] = 0;  fpm[27] = 1; fpm[63] = 0;            
    
    double epsout = 0,emin = 0,emax = 10;
    int N =10,
        lda = N,
        ldb = N,
        loop = 40,
        m0 = 10,
        m = 4,
        info = 0;
    char uplo = 'F';
    double[]  res = new double[N];
    List<string> Errors = new List<string>();
    double[] x = new double[N * m*20];
    double[] Eigenvalues = new double[ m0];
    try
    {
        LAPACK.Init(fpm);
        LAPACK.EigenValuesFEAST(
	           ref uplo, ref N, A, ref lda, /* stiffness*/
	             B, ref ldb, /* mass */
	              fpm, ref epsout, ref loop,
	               ref emin, ref emax,
	             ref m0, Eigenvalues,  x, ref m,  res, ref info);
        
        switch (info)
        {
            case 0: // all is well
                break;
            case 202:
               // there are a lot of error codes that need to be addressed...
               // see the web pages at Intel about FEAST
               break;
            default:
                if (info < -100)
                    throw new ArgumentOutOfRangeException($"Error with argument #{-info - 100}" +
                        " of the Extended Eigensolver interface.");
                else
                    if (info > 100)
                    throw new ArgumentOutOfRangeException($"Problem with {info - 100}-th value of the" +
                        Environment.NewLine +
                        $"input Extended Eigensolver parameter(fpm[{info - 101}])." + Environment.NewLine +
                        "Only the parameters in use are checked.");
                break;
        }
      	double[] Y = new double[] { 0.778167123908170 ,  0.920180634486485,   0.935607276067470 ,  // MathLab
          0.963915607694184 ,  0.985690628059698 ,
          1.015048284381503 ,  1.026313059366515 , 1.063031787597951  , 1.081547590133276,  1.212840409892686 };
        int round = 4;
        double maxError = double.MinValue;
        for (int i=0; i < m0; i++)
            if (Math.Round(Eigenvalues[i], round) != Math.Round(Y[i], round))
            {
                double error = Math.Abs((Eigenvalues[i] - Y[i]) / Y[i]);
                maxError = Math.Max(maxError, error);
                if (error > Math.Pow(10,round+1))
                    throw new Exception($"Error in FEAST Eigenvalues[{i}] : Error =  {error * 100} % ");
            }
                    
        Console.WriteLine($"FEAST OK, Max error {maxError:F2} %");
   	}
	catch (BadImageFormatException bie)
	{
		   Debug.WriteLine(bie.Message + Environment.NewLine + "Probably an x86/x64 confusion");
	}
	catch (Exception ex)
		{
		    Console.WriteLine(ex.Message);		        
		}
    }
        
    public sealed class LAPACK
    {
		string mkl = "mkl_rt.dll"; // make sure it is in your PATH
		[DllImport(mkl , CallingConvention = CallingConvention.Cdecl, EntryPoint = "dfeast_sygv", ExactSpelling = true)]
		static public extern void EigenValuesFEAST(ref char uplo, ref int n, double[,] a, ref int lda,
		   double[,] b, ref int ldb,
		   int[] fpm, ref double epsout, ref int loop,
		   ref double emin, ref double emax,
		   ref int m0, double[] e, double[] x, ref int m, double[] res, ref int info);
    }
