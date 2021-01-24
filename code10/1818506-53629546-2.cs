     using (client)
                    {
                        HttpResponseMessage result = await client.GetAsync(tmpUri);
                        if (result.IsSuccessStatusCode)
                        {
                            var content = await result.Content.ReadAsStringAsync();
                            oc = JsonConvert.DeserializeObject<ObservableCollection<T>>(content);
                          }
                    }
