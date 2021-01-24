    public class GetFileContent : IFileContent { 
        public  byte[] GetFileContent(){
        }
    	// in here there is a method to return the file content
    }
    
    public class ApplyBusinessLogic : IApplyBusinessLogic { 
        public void ApplyLogic(){
 
        }
    	// in here there is a method to get that file content as param and apply business logic
    }
    
    public class UploadContent : IUploadContent{
        public void Upload(){
 
        }
    	// get the modified content and upload it
    }
