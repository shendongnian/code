    using NuGet.Configuration;
    using NuGet.Protocol;
    using NuGet.Protocol.Core.Types;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace MyProject
    {
    	public class NugetHelper
    	{
    		public async Task<string> GetLatestVersionNumberFromNugetFeedAsync(NugetPackage package)
    		{
    			try
    			{
    				Logger logger = new Logger(); //Just a class implementing the Nuget.Common.ILogger interface
    				List<Lazy<INuGetResourceProvider>> providers = new List<Lazy<INuGetResourceProvider>>();
    				providers.AddRange(Repository.Provider.GetCoreV3());  // Add v3 API support
    				PackageSource packageSource = new PackageSource(package.Source.ToString());
    				SourceRepository sourceRepository = new SourceRepository(packageSource, providers);
    				PackageMetadataResource packageMetadataResource = await sourceRepository.GetResourceAsync<PackageMetadataResource>();
    				var searchMetadata = await packageMetadataResource.GetMetadataAsync(package.Name, false, false, new SourceCacheContext(), logger, new CancellationToken());
    				var versionNumber = searchMetadata.FirstOrDefault().Identity.Version.OriginalVersion;
    				return versionNumber;
    			}
    			catch (Exception ex)
    			{
    				return null;
    			}
    		}
    	}
    
    	public class NugetPackage
    	{
    		public string Name { get; set; }
    		public string Version { get; set; }
    		public string MinimumVersion { get; set; }
    		public Uri Source { get; set; }
    	}
    }
