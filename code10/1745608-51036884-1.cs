    using System;
    using System.Linq;
    using System.Net.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Unity;
    using Unity.Microsoft.DependencyInjection;
    using Xunit;
    
    namespace FunctionalTests
    {
    	public class UnityWithHttpClientFactoryTest
    	{
    
    		/// <summary>
    		/// Integration of Unity container with MS ServiceCollection test
    		/// </summary>
    		[Fact]
    		public void HttpClientCanBeCreatedByUnity()
    		{
    			UnityContainer unityContainer = new UnityContainer();
    
    			ServiceCollection serviceCollection = new ServiceCollection();
    			serviceCollection.AddHttpClient("Google", (c) =>
    			{
    				c.BaseAddress = new Uri("https://google.com/");
    			});
    			serviceCollection.BuildServiceProvider(unityContainer);
    
    			Assert.True(unityContainer.IsRegistered<IHttpClientFactory>());
    			IHttpClientFactory clientFactory = unityContainer.Resolve<IHttpClientFactory>();
    			HttpClient httpClient = clientFactory.CreateClient("Google");
    
    			Assert.NotNull(httpClient);
    			Assert.Equal("https://google.com/", httpClient.BaseAddress.ToString());
    
    		}
    
    	}
    }
