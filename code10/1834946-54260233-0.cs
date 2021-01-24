string PAT = "Put PAT String Here";
string RepoStore = "https://url of repo here";
string responseBody = "";
using (HttpClient client = new HttpClient())
{
    client.DefaultRequestHeaders.Accept.Add(
        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
        Convert.ToBase64String(
            System.Text.ASCIIEncoding.ASCII.GetBytes(
                string.Format("{0}:{1}", "", PAT))));
    using (HttpResponseMessage response = client.GetAsync(
                RepoStore + "/_apis/projects").Result)
    {
        response.EnsureSuccessStatusCode();
        responseBody = await response.Content.ReadAsStringAsync();
    }
    Console.WriteLine(responseBody);
}
Console.ReadKey();
