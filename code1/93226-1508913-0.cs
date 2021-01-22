public enum FileUploadType
{
	File,
	Web
}
public interface IProcessingService
{
	void Process();
	object GetResults(); // or whatever you want to do with the results of processing
}
public void Process(FileUploadType fileUploadType)
{
	IProcessingService service;
	
	switch(type)
	{
		case FileUploadType.File: service = new FileUploadProcessingService(); break;
		case FileUploadType.Web: service = new WebUploadProcessingService(); break;
		default: /* log error */ break;
	}
	
	service.Process();
	/* do something with results of processing */
}
