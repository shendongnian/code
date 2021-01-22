    public  class Program
        {
            static void Main(string[] args)
            { 
                int result;
                bool status;
                string s1 = "12345";
                Console.WriteLine("input1:12345");
                string s2 = "1234.45";
                Console.WriteLine("input2:1234.45");
                string s3 = null;
                Console.WriteLine("input3:null");
                string s4 = "1234567899012345677890123456789012345667890";
                Console.WriteLine("input4:1234567899012345677890123456789012345667890");
                string s5 = string.Empty;
                Console.WriteLine("input5:String.Empty");
                Console.WriteLine();
                Console.WriteLine("--------Int.Parse Methods Outputs-------------");
                try
                {
                   result = int.Parse(s1);
    
                   Console.WriteLine("OutPut1:" + result);
                }
                catch (Exception ee)
                {
                    Console.WriteLine("OutPut1:"+ee.Message);
                }
                try
                {
                  result = int.Parse(s2);
    
                  Console.WriteLine("OutPut2:" + result);
                }
                catch (Exception ee)
                {
                    Console.WriteLine("OutPut2:" + ee.Message);
                }
                try
                {
                   result = int.Parse(s3);
    
                   Console.WriteLine("OutPut3:" + result);
                }
                catch (Exception ee)
                {
                    Console.WriteLine("OutPut3:" + ee.Message);
                }
                try
                {
                    result = int.Parse(s4);
    
                    Console.WriteLine("OutPut4:" + result);
                }
                catch (Exception ee)
                {
                    Console.WriteLine("OutPut4:" + ee.Message);
                }
    
                try
                {
                     result = int.Parse(s5);
    
                     Console.WriteLine("OutPut5:" + result);
                }
                catch (Exception ee)
                {
                    Console.WriteLine("OutPut5:" + ee.Message);
                }
                Console.WriteLine();
                Console.WriteLine("--------Convert.To.Int32 Method Outputs-------------");
                try
                {
                   
                    result=  Convert.ToInt32(s1);
    
                    Console.WriteLine("OutPut1:" + result);
                }
                catch (Exception ee)
                {
                    Console.WriteLine("OutPut1:" + ee.Message);
                }
                try
                {
                   
                    result = Convert.ToInt32(s2);
    
                    Console.WriteLine("OutPut2:" + result);
                }
                catch (Exception ee)
                {
                    Console.WriteLine("OutPut2:" + ee.Message);
                }
                try
                {
                  
             result = Convert.ToInt32(s3);
    
             Console.WriteLine("OutPut3:" + result);
                }
                catch (Exception ee)
                {
                    Console.WriteLine("OutPut3:" + ee.Message);
                }
                try
                {
                  
                      result = Convert.ToInt32(s4);
    
                      Console.WriteLine("OutPut4:" + result);
                }
                catch (Exception ee)
                {
                    Console.WriteLine("OutPut4:" + ee.Message);
                }
    
                try
                {
                   
                     result = Convert.ToInt32(s5);
    
                     Console.WriteLine("OutPut5:" + result);
                }
                catch (Exception ee)
                {
                    Console.WriteLine("OutPut5:" + ee.Message);
                }
    
                Console.WriteLine();
                Console.WriteLine("--------TryParse Methods Outputs-------------");
                try
                {
                   
                    status = int.TryParse(s1, out result);
                    Console.WriteLine("OutPut1:" + result);
                }
                catch (Exception ee)
                {
                    Console.WriteLine("OutPut1:" + ee.Message);
                }
                try
                {
                    
                    status = int.TryParse(s2, out result);
                    Console.WriteLine("OutPut2:" + result);
                }
                catch (Exception ee)
                {
                    Console.WriteLine("OutPut2:" + ee.Message);
                }
                try
                {
                   
                    status = int.TryParse(s3, out result);
                    Console.WriteLine("OutPut3:" + result);
                }
                catch (Exception ee)
                {
                    Console.WriteLine("OutPut3:" + ee.Message);
                }
                try
                {
                 
                    status = int.TryParse(s4, out result);
                    Console.WriteLine("OutPut4:" + result);
                }
                catch (Exception ee)
                {
                    Console.WriteLine("OutPut4:" + ee.Message);
                }
    
                try
                {
                   
                    status = int.TryParse(s5, out result);
                    Console.WriteLine("OutPut5:" + result);
                }
                catch (Exception ee)
                {
                    Console.WriteLine("OutPut5:" + ee.Message);
                }
    
    
                Console.Read();
            }
        }
