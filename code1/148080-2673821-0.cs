         Dictionary<string, double> dic = new Dictionary<string,double>();
         string[] items = str.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
         string lastOutput = "";
         for(int index = 0; index < items.Length; index++)
         {
            if(items[index].Contains("output"))
            {
               if(lastOutput.Length > 0 && index > 0)
               {
                  dic.Add(lastOutput, double.Parse(items[index - 1]));
               }
               lastOutput = items[index];
            }
         }
         dic.Add(lastOutput, double.Parse(items[items.Length-1]));
