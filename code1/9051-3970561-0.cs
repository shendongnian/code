    using System.IO;
    using System.Text.RegularExpressions;
    
    public static class PathValidation
    {
    	private static string pathValidatorExpression = "^[^" + string.Join("", Array.ConvertAll(Path.GetInvalidPathChars(), x => Regex.Escape(x.ToString()))) + "]+$";
    	private static Regex pathValidator = new Regex(pathValidatorExpression, RegexOptions.Compiled);
    	
    	private static string fileNameValidatorExpression = "^[^" + string.Join("", Array.ConvertAll(Path.GetInvalidFileNameChars(), x => Regex.Escape(x.ToString()))) + "]+$";
    	private static Regex fileNameValidator = new Regex(fileNameValidatorExpression, RegexOptions.Compiled);
    	
    	private static string pathCleanerExpression = "[" + string.Join("", Array.ConvertAll(Path.GetInvalidPathChars(), x => Regex.Escape(x.ToString()))) + "]";
    	private static Regex pathCleaner = new Regex(pathCleanerExpression, RegexOptions.Compiled);
    	
    	private static string fileNameCleanerExpression = "[" + string.Join("", Array.ConvertAll(Path.GetInvalidFileNameChars(), x => Regex.Escape(x.ToString()))) + "]";
    	private static Regex fileNameCleaner = new Regex(fileNameCleanerExpression, RegexOptions.Compiled);
    	
    	public static bool ValidatePath(string path)
    	{
    		return pathValidator.IsMatch(path);
    	}
    	
    	public static bool ValidateFileName(string fileName)
    	{
    		return fileNameValidator.IsMatch(fileName);
    	}
    	
    	public static string CleanPath(string path)
    	{
    		return pathCleaner.Replace(path, "");
    	}
    	
    	public static string CleanFileName(string fileName)
    	{
    		return fileNameCleaner.Replace(fileName, "");
    	}
    }
