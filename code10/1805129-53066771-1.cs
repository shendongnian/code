    public class Logger {
        public void LogMessage (string message, string myID){
    
            //some logic to write message into a text file with the following message :
    
            // "Id : " + myID + " --> " + message
        // next line (enter)
        }
    }
    public ClassA {
        private Logger logger = new Logger();
        public string myID { get; set; }
    
        // SetID is actually not necessary: just use classAInstance.myID = jobID; in the client of ClassA.
        // But I'd recommend making the Property Readonly and set it through CTOR if possible.
      
    
        public void SomeMethod(){
            ClassB b = new ClassB();
            logger.LogMessage("Execution starts here", myID);
            b.FetchData(logger, myID);
            logger.LogMessage("Further execution", myID);
    
        }
        
    }
    
    public class ClassB(){
    
        public void FetchData( Logger logger, string myID){
            
            logger.LogMessage("Fetch data starts", myID);
            //some logic to fetch data
            logger.LogMessage("Fetch data ends", myID);
        }
    }
