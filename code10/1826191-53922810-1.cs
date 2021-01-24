	public class GitHubReleaseMapper
	{
		public GitHubRelease MapGitHubRelease(JToken jToken)
		{
			GitHubRelease gitHubRelease = new GitHubRelease();
			gitHubRelease.Degree = GetDegree(jToken);
			gitHubRelease.EducationLevel = GetEducationLevel(jToken);
			return gitHubRelease;
		}
		/// <summary>
		/// Get Degree
		/// </summary>
		/// <param name="jToken">jToken</param>
		/// <returns></returns>
		private Degree GetDegree(JToken jToken)
		{
			Degree degree = null;
			//get first item of degree from  JToken
			JToken degreeJToken = jToken.SelectToken("educationInfo.degree[0].string[0]");
			//if found 
			if (degreeJToken != null)
			{
				degree = degreeJToken.ToObject<Degree>();
			}
			return degree;
		}
		/// <summary>
		/// GetEducationLevel
		/// </summary>
		/// <param name="jToken">jToken</param>
		/// <returns></returns>
		private EducationLevel GetEducationLevel(JToken jToken)
		{
			EducationLevel educationLevel = null;
			//get first item of educationLevel from  JToken
			JToken educationLevelJToken = jToken.SelectToken("educationInfo.educationLevel[0]");
			//if found 
			if (educationLevelJToken != null)
			{
				educationLevel = educationLevelJToken.ToObject<EducationLevel>();
			}
			return educationLevel;
		}
	}
	
