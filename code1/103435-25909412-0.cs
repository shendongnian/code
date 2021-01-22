    //using Timer with callback on System.Threading namespace
    //	Timer(TimerCallback callback, object state, int dueTime, int period);
    //		TimerCallback: delegate to callback on timer lapse
    //		state: an object containig information for the callback
    //		dueTime: time delay before callback is invoked; in milliseconds; 0 immediate
    //		period: interval between invocation of callback; System.Threading.Timeout.Infinity to disable
    // EXCEPTIONS:
    //		ArgumentOutOfRangeException: negative duration or period
    //		ArgumentNullException: callback parameter is null
    
    //Example 
    void Main(){
    	var te = new TimerExample(1000,2000, 2);
    }
    public class TimerExample {
    	public TimerExample(int delayTime,int intervalTime, int treshold){
    		this.DelayTime =delayTime;
    		this.IntervalTime = intervalTime;
    		this.Treshold = treshold;  
    		this.Timer = new Timer(this.TimerCallbackWorker, new StateInfo(), delayTime, intervalTime);
    	}
    	public int DelayTime{get; set;}
    	public int IntervalTime{get;set;}
    	public Timer Timer {get; set;}
    	public StateInfo SI{get;set;}
    	public int Treshold{get; private set;} 
    	
    	// timer callback 
    	public void TimerCallbackWorker(object state){
    		var si = state as StateInfo;
    		if(si ==null){
    			throw new ArgumentNullException("state");
    		}	
    		si.ExecutionCounter++;
    		if(si.ExecutionCounter>this.Treshold){
    			this.Timer.Change(Timeout.Infinite, Timeout.Infinite);
    			Console.WriteLine("-Timer stop, execution reached treshold {0}", this.Treshold);
    		}
    		else{
    			Console.WriteLine("{0} lapse, Time {1}",si.ExecutionCounter, si.ToString());
    		}
    	}
    	
    	//state information
    	public class StateInfo{ 
    		public int ExecutionCounter{get;set;}
    		public DateTime LastRun{
    			get { 
    				return DateTime.Now;
    			}
    		}
    		public override string ToString(){
    			return this.LastRun.ToString();
    		}
    	}
    }
     
