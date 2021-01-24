    using System;
    using System.Collections.Generic;    
    using System.Linq;    
    using System.Text;    
    using System.Threading.Tasks;    
    using System.Diagnostics;
    
    public class GainMoney
    {	
    	
    	public int currentMoney = 100;
        public string choose;
    
        
    
        public int addCurrentMoney()
        {
            if ((currentMoney - Farm.costoffarm) > 0)
            {
                System.Threading.Thread.Sleep(50000);
                return currentMoney + 10;
            }
            else
            {
                return currentMoney;
            }
    
        }
    	
    	public void SomeNewMethod(){
    		Console.WriteLine("Please Choose What Are You Wanna Produce");
            choose = Console.ReadLine();
    	}
    }
