        public static int jumpCtr=0;
        public static int ctr=0;
        public static TestFlags gTestFlags = TestFlags.C;
        [Flags] public enum TestFlags { A=1<<1, B=1<<2, C=1<<3 }
        public static void Jump()  { jumpCtr++; gTestFlags = (gTestFlags == TestFlags.B) ? TestFlags.C : TestFlags.B;  }
       
        // IsEnumFlagPresent() https://stackoverflow.com/questions/987607/c-flags-enum-generic-function-to-look-for-a-flag
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool HasFlag_Faster<T>(T value, T lookingForFlag) 
            where T : struct
        {
            int intValue                = (int) (object) value;
            int intLookingForFlag       = (int) (object) lookingForFlag;
            return ((intValue & intLookingForFlag) != 0);
        }
        // IsEnumFlagPresent() https://stackoverflow.com/questions/987607/c-flags-enum-generic-function-to-look-for-a-flag
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool HasFlag_Faster_Integer(int intValue, int intLookingForFlag) 
        {
            return ((intValue & intLookingForFlag) != 0);
        }
        public static void Benchmark_HasFlag( )  
        {
            if ( ! hwDvr._weAreOnGswCpu) { return; }
            DateTime timer = DateTime.Now; 
            string a, b, c, d, e;
            double base_nSecPerLoop, b_nSecPerLoop, c_nSecPerLoop, d_nSecPerLoop, e_nSecPerLoop;
            int numOfLoops = (int) 1.0e6;
            //  ------------------------------------------------------
            for (int i=0; i<numOfLoops;i++) {
                Jump();
            }
            a = BenchMarkSystem_Helper.SimpleTimer_Loops( ref timer, numOfLoops, out base_nSecPerLoop);
            
            //  ------------------------------------------------------
            //  BENCHMARK: 50 nSec
            
            for (int i=0; i<numOfLoops;i++) {
                if (gTestFlags.HasFlag((TestFlags) TestFlags.C)) {   
                    ctr++;
                }
                Jump();
            }
            b = BenchMarkSystem_Helper.SimpleTimer_Loops( ref timer, numOfLoops, out b_nSecPerLoop );
            double b_diff = b_nSecPerLoop - base_nSecPerLoop;
            //  ------------------------------------------------------
            //  BENCHMARK: 3 nSec
            
            for (int i=0; i<numOfLoops;i++) {
                if ((gTestFlags & TestFlags.C) != 0) {   
                    ctr++;
                }
                Jump();
            }
            c = BenchMarkSystem_Helper.SimpleTimer_Loops( ref timer, numOfLoops, out c_nSecPerLoop );
            double c_diff = c_nSecPerLoop - base_nSecPerLoop;
            //  ------------------------------------------------------
            //  BENCHMARK: 64 nSec
            for (int i=0; i<numOfLoops;i++) {
                if (HasFlag_Faster<TestFlags>(value:gTestFlags, lookingForFlag: TestFlags.C)) {   
                    ctr++;
                }
                Jump();
            }
            d = BenchMarkSystem_Helper.SimpleTimer_Loops( ref timer, numOfLoops, out d_nSecPerLoop );
            double d_diff = d_nSecPerLoop - base_nSecPerLoop;
            //  ------------------------------------------------------
            //  BENCHMARK: 14 nSec
            for (int i=0; i<numOfLoops;i++) {
                if (HasFlag_Faster_Integer((int)gTestFlags, (int)TestFlags.C)) {   
                    ctr++;
                }
                Jump();
            }
            e = BenchMarkSystem_Helper.SimpleTimer_Loops( ref timer, numOfLoops, out e_nSecPerLoop );
            double e_diff = e_nSecPerLoop - base_nSecPerLoop;
            int brkPt=0;
        }
