        public class Solution
    {
        //internal class SolutionParser
        //Name: Microsoft.Build.Construction.SolutionParser
        //Assembly: Microsoft.Build, Version=4.0.0.0
    
        static readonly Type s_SolutionParser;
        static readonly PropertyInfo s_SolutionParser_solutionReader;
        static readonly MethodInfo s_SolutionParser_parseSolution;
        static readonly PropertyInfo s_SolutionParser_projects;
        static readonly PropertyInfo s_SolutionParser_configurations;//this was missing in john's answer
    
    
        static Solution()
        {
            s_SolutionParser = Type.GetType("Microsoft.Build.Construction.SolutionParser, Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", false, false);
            if ( s_SolutionParser != null )
            {
                s_SolutionParser_solutionReader = s_SolutionParser.GetProperty("SolutionReader", BindingFlags.NonPublic | BindingFlags.Instance);
                s_SolutionParser_projects = s_SolutionParser.GetProperty("Projects", BindingFlags.NonPublic | BindingFlags.Instance);
                s_SolutionParser_parseSolution = s_SolutionParser.GetMethod("ParseSolution", BindingFlags.NonPublic | BindingFlags.Instance);
                s_SolutionParser_configurations = s_SolutionParser.GetProperty("SolutionConfigurations", BindingFlags.NonPublic | BindingFlags.Instance); //this was missing in john's answer
    
                // additional info:
                var PropNameLst = GenHlp_PropBrowser.PropNamesOfType(s_SolutionParser);
                // the above call would yield something like this:
                // [ 0]	"SolutionParserWarnings"	    string
                // [ 1]	"SolutionParserComments"	    string
                // [ 2]	"SolutionParserErrorCodes"	    string
                // [ 3]	"Version"	                    string
                // [ 4]	"ContainsWebProjects"	        string
                // [ 5]	"ContainsWebDeploymentProjects"	string
                // [ 6]	"ProjectsInOrder"	            string
                // [ 7]	"ProjectsByGuid"	            string
                // [ 8]	"SolutionFile"	                string
                // [ 9]	"SolutionFileDirectory"	        string
                // [10]	"SolutionReader"	            string
                // [11]	"Projects"	                    string
                // [12]	"SolutionConfigurations"	    string
            }
        }
    
        public List<SolutionProject> Projects { get; private set; }
        public List<SolutionConfiguration> Configurations { get; private set; }
    
       //...
       //...
       //... no change in the rest of the code
    }
