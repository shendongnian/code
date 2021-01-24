           while(true)
            {
                try
                {
                    Console.WriteLine($"Invoking method On moduleA");
                    var deviceId = System.Environment.GetEnvironmentVariable("IOTEDGE_DEVICEID");
                    MethodRequest request = new MethodRequest("MethodA", Encoding.UTF8.GetBytes("{ \"Message\": \"Hello\" }"));
                    var response = await ioTHubModuleClient.InvokeMethodAsync(deviceId, "ModuleA", request).ConfigureAwait(false);
                    Console.WriteLine($"Received response with status {response.Status}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error invoking method {ex}");
                }
                await Task.Delay(TimeSpan.FromSeconds(20)).ConfigureAwait(false);
            }
