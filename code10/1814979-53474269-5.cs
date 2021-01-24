    public class DoMyAction { 
    
    	IFileContent _content;
        // call the method in above class and get the content
    
        IApplyBusinessLogic _doMyThing;
        // do my stuff using that file content
    
        IUploadContent _uploader;
        // upload the content
    
    
        public DoMyAction(IFileContent content,IApplyBusinessLogic doMyThing,IUploadContent uploader){
            _content  = content;
            _doMyThing = doMyThing;
            _uploader = uploader;
        }
    	
        public void excuteAPI(){
          //doing something here
        }
    }
