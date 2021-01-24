    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp16
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] dateList = { "01/10/2018", "02/10/2018", "03/10/2018", "04/10/2018", "05/10/2018", "06/10/2018" };
                Dictionary<string, bool> markStatus = new Dictionary<string, bool>()
                {
                    {"01/10/2018",true } ,
                    {"03/10/2018",true },
                    {"05/10/2018",false }
                };
    
                Dictionary<string, bool> result = new Dictionary<string, bool>();
    
                bool flag;
    
                foreach (var item in dateList)
                {
                    flag = false;
                    foreach (var key in markStatus.Keys)
                    {
                        if (item.Equals(key))
                        {
                            result.Add(item, markStatus[key]);
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        result.Add(item, false);
                    }
                }
    
    
            }
        }
    
    }
