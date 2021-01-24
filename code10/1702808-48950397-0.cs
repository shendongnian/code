    public virtual async Task<TResponse> PostFileAsync<TResponse>(string url, Dictionary<string, string> headers, FileResponse fileData, IProgress<ProgressCompleted> progress, CancellationToken token)
		{
			using (var request = new HttpRequestMessage(HttpMethod.Post, url))
			{
				List<byte> byteData = new List<byte>();
				Action<double> actionProgress = null;
				if (progress != null)
				{
					actionProgress = (progressValue) => progress.Report(new ProgressCompleted(progressValue));
				}
				var boundary = string.Format("----------{0:N}", Guid.NewGuid());
				var multiContent = new MultipartFormDataContent(boundary);
				foreach (var customHeader in headers)
				{
					request.Headers.Add(customHeader.Key, customHeader.Value);
				}
				var content = new ByteArrayContent(fileData.FileData);
				content.Headers.TryAddWithoutValidation("Content-Type", fileData.FileType);
				multiContent.Add(content, "file", fileData.FileName);
				request.Content = multiContent;
				using (var response = await Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, token).ConfigureAwait(false))
				{
					var total = response.Content.Headers.ContentLength.HasValue ? response.Content.Headers.ContentLength.Value : -1L;
					var canReportProgress = total != -1 && progress != null;
					if (!response.IsSuccessStatusCode)
						RestExceptionHandlerService.Handle(response.StatusCode);
					using (var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
					{
						var totalRead = 0L;
						var buffer = new byte[BufferSize];
						var isMoreToRead = true;
						do
						{
							token.ThrowIfCancellationRequested();
							var read = await stream.ReadAsync(buffer, 0, buffer.Length, token).ConfigureAwait(false);
							if (read == 0)
							{
								isMoreToRead = false;
							}
							else
							{
								if (read != buffer.Length)
								{
									byte[] cpArray = new byte[read];
									Array.Copy(buffer, cpArray, read);
									byteData.AddRange(cpArray);
								}
								else {
									byteData.AddRange(buffer);
								}
								totalRead += read;
								if (canReportProgress)
								{
									progress.Report(new ProgressCompleted((double)totalRead / total * 100));
								}
							}
						} while (isMoreToRead);
					}
					//TODO: server returns just string NOT Json
					return (TResponse)(object) Encoding.UTF8.GetString(byteData.ToArray(), 0, byteData.Count);
				}
			}
		}
