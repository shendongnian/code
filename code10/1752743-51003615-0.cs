    var Content = "nickname:Steven ID:01 nickname:pascal ID:02 nickname:nils ID:03";
    		var v = Content.Split().Where(l => l.StartsWith("nickname:")).ToList();
    		var c = Content.Split().Where(l => l.StartsWith("ID:")).ToList();
                for(int i = 0; i < v.Count(); i++)
                {
                    var x = v[i];
    				var ids = c[i];
    				Console.Write(x.ToString() + " - ");
    				Console.WriteLine(ids.ToString());
                    
    			}
