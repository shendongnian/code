    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    using UnityEngine;
					
    public class Program
    {    	
    	private void MainGeneration(
                Color32[] source,
                Color32[] target,
                int width,
                int height)
        {
            Parallel.ForEach(Partitioner.Create(source, true)
                    .GetOrderableDynamicPartitions(), colorItem =>
            {
    			var i = colorItem.Key;
    			var color = colorItem.Value;
    			var x = i % width;
    			var y = height - i / width - 1;
    			target[i] = this.Map(color, i, x, y);
            });
        }
    						 
    	private Color32 Map(Color32 color, long i, long x, long y)
    	{
    		return color;	
    	}				 
    }
