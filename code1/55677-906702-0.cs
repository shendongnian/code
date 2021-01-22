		private NC3A.SI.Rowlex.AssemblyGenerator generator;
		private void RunAssemblyGeneration(XmlDocument ontologyFileInRdfXml)
		{
			this.generator = new NC3A.SI.Rowlex.AssemblyGenerator();
			this.generator.GenerateAsync(ontologyFileInRdfXml, "myAssemblyName", 
                                            null, this.OnGenerationFinished);
		}
		private void OnGenerationFinished(string errorMessage)
		{
				if (errorMessage == null)
				{
					// Success
					// Displaying warnings (if there is any) and saving result
					string[] warnings = this.generator.Warnings;
					this.generator.SaveResult(@"C:\myAssemblyName.dll");
                    // Important! One generator instance can be executed only once. 
    				this.generator = null; 
    				this.RejoiceOverSuccess();
    			}
   			else
   			{
    				// Failure
    				this.MournOverFailure();
    			}
    		}
    	}
