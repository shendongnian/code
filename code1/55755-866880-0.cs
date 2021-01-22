    [Serializable]
    public class FileMetaDataDto
    {
	    .
	    . a constructor...   etc and several other properties edited for brevity
	    . 
	    
	    public int Id { get; private set; }
	    public string Version { get; private set; }
	    public List<MetaDataValueDto> CustomFields { get; set; }
    
    }
