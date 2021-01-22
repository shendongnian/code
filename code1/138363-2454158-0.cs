            var answer = "No";
            try
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception e)
                {
                    e.Data.Add("mykey", "myvalue");
                    throw;
                }
            }
            catch (Exception e)
            {
                if((string)e.Data["mykey"] == "myvalue")
                    answer = "Yes";
            }
            Console.WriteLine(answer);
            Console.ReadLine();     
