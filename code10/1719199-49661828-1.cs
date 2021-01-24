    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var tcs = new TaskCompletionSource<bool>();
                string reply = string.Empty;
                Task.Run(async () =>
                {
                    try
                    {
                        using (var httpClient = new HttpClient())
                        {
                            var httpContent = new StringContent("{\"Image\":\"busybox\"}", Encoding.UTF8, "application/json");
                            var result = await httpClient.PostAsync("http://localhost:2375/v1.29/containers/create?name=bussybox", httpContent);
                            reply = await result.Content.ReadAsStringAsync();
                        }
                    }
                    catch (Exception ex)
                    {
                        reply = ex.Message;
                        tcs.TrySetResult(false);
                    }
                });
                tcs.Task.Wait();
                Console.WriteLine(reply);
            }
        }
    }
