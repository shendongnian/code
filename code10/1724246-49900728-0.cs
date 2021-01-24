    using Microsoft.Build.Construction;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    
    using System.Linq;
    
    namespace MSBuild.Common
    {
    	class Builder : Task
    	{
    		[Required]
    		public string Solution { get; set; }
    
    		public override bool Execute()
    		{
    			return BuildEngine2.BuildProjectFilesInParallel(GetSolutionProject(), null, null, null, null, true, false);
    		}
    
    		public string[] GetSolutionProject()
    		{
    			return SolutionFile.Parse(Solution).ProjectsByGuid.Select(p => p.Value.AbsolutePath).ToArray();
    		}
    	}
    }
