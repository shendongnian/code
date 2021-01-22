    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    using System.Text;
    public class Program
    {
        [DebuggerDisplay("{ProjectName}, {RelativePath}, {ProjectGuid}")]
        public class SolutionProject
        {
            public string ParentProjectGuid;
            public string ProjectName;
            public string RelativePath;
            public string ProjectGuid;
            public string AsSlnString()
            { 
                return "Project(\"" + ParentProjectGuid + "\") = \"" + ProjectName + "\", \"" + RelativePath + "\", \"" + ProjectGuid + "\"";
            }
        }
    /// <summary>
    /// .sln loaded into class.
    /// </summary>
    public class Solution
    {
        public List<object> slnLines;       // List of either String (line format is not intresting to us), or SolutionProject.
        /// <summary>
        /// Loads visual studio .sln solution
        /// </summary>
        /// <param name="solutionFileName"></param>
        /// <exception cref="System.IO.FileNotFoundException">The file specified in path was not found.</exception>
        public Solution( string solutionFileName )
        {
            slnLines = new List<object>();
            String slnTxt = File.ReadAllText(solutionFileName);
            string[] lines = slnTxt.Split('\n');
            //Match string like: Project("{66666666-7777-8888-9999-AAAAAAAAAAAA}") = "ProjectName", "projectpath.csproj", "{11111111-2222-3333-4444-555555555555}"
            Regex projMatcher = new Regex("Project\\(\"(?<ParentProjectGuid>{[A-F0-9-]+})\"\\) = \"(?<ProjectName>.*?)\", \"(?<RelativePath>.*?)\", \"(?<ProjectGuid>{[A-F0-9-]+})");
            Regex.Replace(slnTxt, "^(.*?)[\n\r]*$", new MatchEvaluator(m =>
                {
                    String line = m.Groups[1].Value;
                    Match m2 = projMatcher.Match(line);
                    if (m2.Groups.Count < 2)
                    {
                        slnLines.Add(line);
                        return "";
                    }
                    SolutionProject s = new SolutionProject();
                    foreach (String g in projMatcher.GetGroupNames().Where(x => x != "0")) /* "0" - RegEx special kind of group */
                        s.GetType().GetField(g).SetValue(s, m2.Groups[g].ToString());
                    slnLines.Add(s);
                    return "";
                }), 
                RegexOptions.Multiline
            );
        }
        /// <summary>
        /// Gets list of sub-projects in solution.
        /// </summary>
        /// <param name="bGetAlsoFolders">true if get also sub-folders.</param>
        public List<SolutionProject> GetProjects( bool bGetAlsoFolders = false )
        {
            var q = slnLines.Where( x => x is SolutionProject ).Select( i => i as SolutionProject );
        
            if( !bGetAlsoFolders )  // Filter away folder names in solution.
                q = q.Where( x => x.RelativePath != x.ProjectName );
        
            return q.ToList();
        }
        /// <summary>
        /// Saves solution as file.
        /// </summary>
        public void SaveAs( String asFilename )
        {
            StringBuilder s = new StringBuilder();
            for( int i = 0; i < slnLines.Count; i++ )
            {
                if( slnLines[i] is String ) 
                    s.Append(slnLines[i]);
                else
                    s.Append((slnLines[i] as SolutionProject).AsSlnString() );
                if( i != slnLines.Count )
                    s.AppendLine();
            }
    
            File.WriteAllText(asFilename, s.ToString());
        }
    }
        static void Main()
        {
            String projectFile = @"yourown.sln";
            try
            {
                String outProjectFile = Path.Combine(Path.GetDirectoryName(projectFile), Path.GetFileNameWithoutExtension(projectFile) + "_2.sln");
                Solution s = new Solution(projectFile);
                foreach( var proj in s.GetProjects() )
                {
                    Console.WriteLine( proj.RelativePath );
                }
                SolutionProject p = s.GetProjects().Where( x => x.ProjectName.Contains("Plugin") ).First();
                p.RelativePath = Path.Combine( Path.GetDirectoryName(p.RelativePath) , Path.GetFileNameWithoutExtension(p.RelativePath) + "_Variation" + ".csproj");
                s.SaveAs(outProjectFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
