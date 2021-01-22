    namespace MixedTests
    {
    	[TestClass]
    	public class ExtensionsTests
    	{
    		[TestMethod]
    		public void Difference_int_Test()
    		{
    			int res2 = Functions.Difference<int>(5, 7);
    			int res3 = Functions.Difference<int>(-3, 0);
    			int res6 = Functions.Difference<int>(-3, -9);
    			int res8 = Functions.Difference<int>(3, -5);
    
    			Assert.AreEqual(19, res2 + res3 + res6 + res8);
    		}
    
    		[TestMethod]
    		public void Difference_float_Test()
    		{
    			float res2_1 = Functions.Difference<float>(5.1, 7.2);
    			float res3_1 = Functions.Difference<float>(-3.1, 0);
    			double res5_9 = Functions.Difference<double>(-3.1, -9);
    			decimal res8_3 = Functions.Difference<decimal>(3.1, -5.2);
    
    			Assert.AreEqual((float)2.1, res2_1);
    			Assert.AreEqual((float)3.1, res3_1);
    			Assert.AreEqual(5.9, res5_9);
    			Assert.AreEqual((decimal)8.3, res8_3);
    
    		}
    	}
    }
