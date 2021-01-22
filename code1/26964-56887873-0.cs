    using System;
    using System.Collections.Generic;
    
    namespace console_test
    {
    	class Program
    	{
    		#region SaveFormat
    		internal enum SaveFormat
    		{
    			DOCX,
    			PDF
    		}
    		
    		internal static Dictionary<SaveFormat,string> DictSaveFormat = new Dictionary<SaveFormat, string>
    		{
    			{ SaveFormat.DOCX,"This is value for DOCX enum item" },
    			{ SaveFormat.PDF,"This is value for PDF enum item" }
    		};
    		
    		internal static void enum_value_test(SaveFormat save_format)
    		{
    			Console.WriteLine(DictSaveFormat[save_format]);
    		}
    		#endregion
    		
    		internal static void Main(string[] args)
    		{
    			enum_value_test(SaveFormat.DOCX);//Output: This is value for DOCX enum item
    			Console.Write("Press any key to continue . . . ");
    			Console.ReadKey(true);
    		}
    	}
    }
