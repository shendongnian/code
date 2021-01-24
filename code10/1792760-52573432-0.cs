    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Xunit;
    using Xunit.Abstractions;
    
    namespace CountNumberTest
    {
        public class WebBrowserReplaceHtmlFromDatabaseTest
        {
            private const string BaseAddress = "https://stackoverflow.com/questions/52572969/count-number-of-occurrence";
    
            private readonly ITestOutputHelper Output;
            private static readonly HttpClient StaticHttpComponent = new HttpClient
            {
                BaseAddress = new Uri(BaseAddress)
            };
    
            public WebBrowserReplaceHtmlFromDatabaseTest(ITestOutputHelper output)
            {
                this.Output = output;
            }
    
            [Fact]
            public async Task When_GetHtmlBodyFromWebPage_Then_ReplaceAllWordInHtml()
            {
                var replaceWordCollection = new[] { "html", "I", "in", "on" };
                var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseAddress}");
    
                HttpResponseMessage response = await StaticHttpComponent.SendAsync(request);
    
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    
                StringBuilder buffer = new StringBuilder(await response.Content.ReadAsStringAsync());
    
                Assert.NotEqual(0, buffer.Length);
    
                foreach (string word in replaceWordCollection)
                {
                    int len = word.Length;
    
                    int countOccurrence = Regex.Matches(buffer.ToString(), word).Count;
                    var replaceWord = new string('*', len);
    
                    Output.WriteLine($"{word} - occurred: {countOccurrence}");
                    buffer.Replace(word, replaceWord);
                }
    
                string html = buffer.ToString();
                foreach (string word in replaceWordCollection)
                    Assert.DoesNotContain(word, html);
    
                Output.WriteLine(html);
            }
        }
    }
