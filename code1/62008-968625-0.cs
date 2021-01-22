    using System;
    
    public enum BatchFile
    {
    	[BatchFile("Batch1.bat")]
    	batch1,
    	[BatchFile("Batch2.bat")]
    	batch2
    }
    
    public class BatchFileAttribute : Attribute
    {
    	public string FileName;
    	public BatchFileAttribute(string fileName) { FileName = fileName; }
    }
    
    public class Test
    {
    	public static string GetFileName(Enum enumConstant)
    	{
    		if (enumConstant == null)
    			return string.Empty;
    
    		System.Reflection.FieldInfo fi = enumConstant.GetType().GetField(enumConstant.ToString());
    		BatchFileAttribute[] aattr = ((BatchFileAttribute[])(fi.GetCustomAttributes(typeof(BatchFileAttribute), false)));
    		if (aattr.Length > 0)
    			return aattr[0].FileName;
    		else
    			return enumConstant.ToString();
    	}
    }
