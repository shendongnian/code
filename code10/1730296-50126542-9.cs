    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program {
    	public static void Main() {
    		var data = new List<Order> {
    			new Order("prod1", "cat1", "sub1"),
    			new Order("prod1", "cat2", "sub2"),
    			new Order("prod2", "cat3", "sub6"),
    			new Order("prod1", "cat1", "sub1"),
    			new Order("prod5", "cat2", "sub8"),
    			new Order("prod2", "cat1", "sub1"),
    			new Order("prod1", "cat7", "sub3"),
    			new Order("prod8", "cat2", "sub2"),
    			new Order("prod2", "cat3", "sub1")
    		};
    		int max = 0;
    		var items = data
    			.SelectMany(o => new List<KeyValuePair<int, string>> {
    				new KeyValuePair<int, string>(1, o.Products),
    				new KeyValuePair<int, string>(2, o.Categories),
    				new KeyValuePair<int, string>(3, o.Subcategories)
    			})
    			.Distinct()
    			.GroupBy(d => d.Key)
    			.Select(g => {
    				var l = g.Select(d => d.Value).ToList();
    				max = Math.Max(max, l.Count);
    				return l;
    			})
    			.ToList();
    		Enumerable
    			.Range(0, max)
    			.Select(i => new {
    				p = items[0].ItemAtOrDefault(i, null),
    				c = items[1].ItemAtOrDefault(i, null),
    				s = items[2].ItemAtOrDefault(i, null)
    			})
    			.ToList()
    			.ForEach(r => Console.WriteLine($"p: {r.p}, c: {r.c}, s: {r.s}"));
    	}
    }
    
    public static class ListExtensions {
    	public static T ItemAtOrDefault<T>(this List<T> list, int index, T defaultValue)
    		=> index >= list.Count ? defaultValue : list[index];
    }
    
    public class Order {
    	public Order(string products, string categories, string subcategories) {
    		Products = products;
    		Categories = categories;
    		Subcategories = subcategories;
    	}
    	public string Products { get; set; }
    	public string Categories { get; set; }
    	public string Subcategories { get; set; }
    }
