    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1 {
    	class Program {
    		static void Main(string[] args) {
    
    			int resultX = -1;
    			int resultY = -1;
    			int sourceX = 5005;
    			int sourceY = 5000;
    			int targetX = 4096;
    			int targetY = 4096;
    
    			if (sourceX <= targetX) { resultX = sourceX; }
    			if (sourceY <= targetY) { resultY = sourceY; }
    			if (IsValid(resultX, resultY)) {
    				//	return the results
    				Console.WriteLine($"x={resultX}, y={resultY}");
    				return;
    			}
    
    			for (int index=targetX; 0 < index; index--) {
    				double result = (double)sourceX / index;
    				if (0 == result - (int)result) {
    					resultX = index;
    					break;
    				}
    			}
    
    			for (int index = targetY; 0 < index; index--) {
    				double result = (double)sourceY / index;
    				if (0 == result - (int)result) {
    					resultY = index;
    					break;
    				}
    			}
    
    			Console.WriteLine($"x={resultX}, y={resultY}");
    			Console.ReadKey(true);
    		}
    
    
    		static bool IsValid(int x, int y) {
    			return (-1 != x) && (-1 != y);
    		}
    	}
    }
