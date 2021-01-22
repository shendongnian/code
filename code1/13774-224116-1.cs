    using System;
    using System.IO;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    
    namespace CredibleCustomBuildTasks
    {
    	public class IncrementTask : Task
    	{
    		[Required]
    		public bool SaveChange { get; set; }
    
    		[Required]
    		public string IncrementFileName { get; set; }
    
    		[Output]
    		public int Increment { get; set; }
    
    		public override bool Execute()
    		{
    			if (File.Exists(IncrementFileName))
    			{
    				string lines = File.ReadAllText(IncrementFileName);
    				int result;
    				if(Int32.TryParse(lines, out result))
    				{
    					Increment = result + 1;
    				}
    				else
    				{
    					Log.LogError("Unable to parse integer in '{0}' (contents of {1})");
    					return false;
    				}
    			}
    			else
    			{
    				Increment = 1;
    			}
    
    			if (SaveChange)
    			{
    				File.Delete(IncrementFileName);
    				File.WriteAllText(IncrementFileName, Increment.ToString());
    			}
    			return true;
    		}
    	}
    }
