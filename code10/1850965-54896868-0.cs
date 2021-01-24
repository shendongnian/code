    public class PartialFileStreamResult : FileResult
	{
		Stream stream;
		long bytes;
		/// <summary>
		/// Creates a new <see cref="PartialFileStreamResult"/> instance with
		/// the provided <paramref name="fileStream"/> and the
		/// provided <paramref name="contentType"/>, which will download the first <paramref name="bytes"/>.
		/// </summary>
		/// <param name="stream">The stream representing the file</param>
		/// <param name="contentType">The Content-Type header for the response</param>
		/// <param name="bytes">The number of bytes to send from the start of the file</param>
		public PartialFileStreamResult(Stream stream, string contentType, long bytes)
			: base(contentType)
		{
			this.stream = stream ?? throw new ArgumentNullException(nameof(stream));
			if (bytes == 0)
			{
				throw new ArgumentOutOfRangeException(nameof(bytes), "Invalid file length");
			}
			this.bytes = bytes;
		}
		/// <summary>
		/// Gets or sets the stream representing the file to download.
		/// </summary>
		public Stream Stream
		{
			get => stream;
			set => stream = value ?? throw new ArgumentNullException(nameof(stream));
		}
		/// <summary>
		/// Gets or sets the number of bytes to send from the start of the file.
		/// </summary>
		public long Bytes
		{
			get => bytes;
			set
			{
				if (value == 0)
				{
					throw new ArgumentOutOfRangeException(nameof(bytes), "Invalid file length");
				}
				bytes = value;
			}
		}
		/// <inheritdoc />
		public override Task ExecuteResultAsync(ActionContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}
			var executor = context.HttpContext.RequestServices.GetRequiredService<IActionResultExecutor<PartialFileStreamResult>>();
			return executor.ExecuteAsync(context, this);
		}
	}
    public class PartialFileStreamResultExecutor : FileResultExecutorBase, IActionResultExecutor<PartialFileStreamResult>
	{
		public PartialFileStreamResultExecutor(ILoggerFactory loggerFactory)
			: base(CreateLogger<PartialFileStreamResultExecutor>(loggerFactory))
		{
		}
		public async Task ExecuteAsync(ActionContext context, PartialFileStreamResult result)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}
			if (result == null)
			{
				throw new ArgumentNullException(nameof(result));
			}
			using (result.Stream)
			{
				long length = result.Bytes;
				var (range, rangeLength, serveBody) = SetHeadersAndLog(context, result, length, result.EnableRangeProcessing);
				if (!serveBody) return;
				try
				{
					var outputStream = context.HttpContext.Response.Body;
					if (range == null)
					{
						await StreamCopyOperation.CopyToAsync(result.Stream, outputStream, length, bufferSize: BufferSize, cancel: context.HttpContext.RequestAborted);
					}
					else
					{
						result.Stream.Seek(range.From.Value, SeekOrigin.Begin);
						await StreamCopyOperation.CopyToAsync(result.Stream, outputStream, rangeLength, BufferSize, context.HttpContext.RequestAborted);
					}
				}
				catch (OperationCanceledException)
				{
					// Don't throw this exception, it's most likely caused by the client disconnecting.
					// However, if it was cancelled for any other reason we need to prevent empty responses.
					context.HttpContext.Abort();
				}
			}
		}
	}
