    using Microsoft.Build.Construction;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using System.Linq;
    
    namespace MSBuild.Common
    {
    	class Build : Task
    	{
    		[Required]
    		public string Solution
    		{
    			get;
    			set;
    		}
    
    		public override bool Execute()
    		{
    			return BuildEngine2.BuildProjectFilesInParallel(SolutionFile.Parse(Solution).ProjectsByGuid.Select(p => p.Value.AbsolutePath).ToArray(), null, null, null, null, true, false);
    		}
    	}
    }
