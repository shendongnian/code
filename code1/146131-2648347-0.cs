    	public void OnPublishBegin(ref bool pubContinue)
		{
			if (pubContinue && _applicationObject.Solution.SolutionBuild.ActiveConfiguration.Name != "Release")
			{
				System.Windows.Forms.MessageBox.Show("You can only publish a Release build");
				pubContinue = false;
			}
		}
