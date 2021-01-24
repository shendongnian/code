    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public class Subscriber{
    		public string Name {get;set;}
    		public List<Subscription> Subscriptions{get;set;}
    	}
    	
    	public class Subscription{
    		public string Name {get;set;}
    	}
    	
    	public class MyViewModelItem{
    		public string SubscriberName{get;set;}
    		public string SubscriptionNames {get;set;}
    	}
    	
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		
            // create some dummy data
    		var data = new List<Subscriber>{
    			new Subscriber{
    				Name = "Arnold",
    				Subscriptions = new List<Subscription>(){
    					new Subscription{
    						Name = "Subscription A"
    					},
    					new Subscription{
    						Name = "Subscription B"
    					},
    					new Subscription{
    						Name = "Subscription C"
    					}
    				}
    			},
    			new Subscriber{
    				Name = "Betty",
    					Subscriptions = new List<Subscription>()
    			},
    			new Subscriber{
    				Name = "Christopher",
    				Subscriptions = new List<Subscription>(){
    					new Subscription{
    						Name = "Subscription A"
    					}
    				}
    			}
    		};
    		
            // here's the query and it becomes much simpler
    		var myViewModel = data
    			.Select(i=> new MyViewModelItem{
    				SubscriberName = i.Name,
    				SubscriptionNames = string.Join(", ", i.Subscriptions.Select(j=>j.Name))
    			})
    			.ToList();
    		
            // this shows the output
    		foreach(var item in myViewModel){
    			Console.WriteLine(string.Format("subscriber: {0}, subscriptions: {1}",item.SubscriberName,item.SubscriptionNames));
    		}
    		
    	}
    }
