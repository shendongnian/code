    using System;
    using System.Text;
    using Newtonsoft.Json;
    
    public class Program
    {
    	public static void Main()
    	{
            string msg = "dummy text here";
            byte[] utfBytes = System.Text.Encoding.UTF8.GetBytes(msg);
            string hex = BitConverter.ToString(utfBytes).Replace("-", "");
            
            var obj = new
            {
                Mess = new[]
                {
                    new
                    {
                        Msg = new
                        {
                            MsgTitle = hex,
                            MsgBody = hex
                        }
                    }
                }
            };
            
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            Console.WriteLine(json);
    	}
    }
