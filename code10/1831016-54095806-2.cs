    class Program
    	{
    		private static readonly List<Batch> BatchList = new List<Batch>();
    		private static readonly BlockingCollection<Message> Messages = new BlockingCollection<Message>();
    
    		private const int Maxbatchsize = 240;
    		private static int _currentsize;
    
    		private static void Producer()
    		{
    			int ctr = 1;
    			while (ctr <= 11)
    			{
    				Messages.Add(new Message { Id = ctr, Name = $"Name-{ctr}" });
    				Thread.Sleep(1000);
    				ctr++;
    			}
    			Messages.CompleteAdding();
    		}
    
    		private static void Consumer()
    		{
    			foreach (var message in Messages.GetConsumingEnumerable())
    			{
    				if (_currentsize >= Maxbatchsize)
    				{
    					var listToWrite = new Batch[BatchList.Count];
    					BatchList.CopyTo(listToWrite);
    					BatchList.Clear();
    					_currentsize = 0;
    					WriteToFile(listToWrite.ToList());
    				}
    				else
    				{
    					Thread.Sleep(1000);
    					if (Messages.IsAddingCompleted)
    					{
    						var remainSize = Messages.Select(JsonConvert.SerializeObject).Sum(x => x.Length);
    						if (remainSize == 0)
    						{
    							var lastMsg = JsonConvert.SerializeObject(message);
    							BatchList.Add(new Batch { Message = message });
    							_currentsize += lastMsg.Length;
    							Console.WriteLine(lastMsg);
    							var additionListToWrite = new Batch[BatchList.Count];
    							BatchList.CopyTo(additionListToWrite);
    							BatchList.Clear();
    							_currentsize = 0;
    							WriteToFile(additionListToWrite.ToList());
     							break;
    						}
    					}
    				}
    
    				var msg = JsonConvert.SerializeObject(message);
    				BatchList.Add(new Batch { Message = message });
    				_currentsize += msg.Length;
    				Console.WriteLine(msg);
    			}
    		}
    
    		private static void WriteToFile(List<Batch> listToWrite)
    		{
    			using (StreamWriter outFile = System.IO.File.CreateText(Path.Combine(@"C:\TEMP", $"{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.json")))
    			{
    				outFile.Write(JsonConvert.SerializeObject(listToWrite));
    			}
    		}
    
    		static void Main(string[] args)
    		{
    			var producer = Task.Factory.StartNew(() => Producer());
    			var consumer = Task.Factory.StartNew(() => Consumer());
    			Console.Read();
    		}
    	}
