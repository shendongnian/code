        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            // Ensure the file has contents before processing.
            if (file == null || file.Length == 0)
                throw new ApiException("Csv file should not be null", HttpStatusCode.BadRequest)
                    .AddApiExceptionResponseDetails(ErrorTypeCode.ValidationError, ErrorCode.BelowMinimumLength, SOURCE); 
            // Ensure the file is not over the allowed limit.
            if (file.Length > (_settings.MaxCsvFileSize * 1024))
                throw new ApiException("Max file size exceeded, limit of " + _settings.MaxCsvFileSize + "mb", HttpStatusCode.BadRequest)
                    .AddApiExceptionResponseDetails(ErrorTypeCode.ValidationError, ErrorCode.ExceedsMaximumLength, SOURCE); 
            
            // Ensure the file type is csv and content type is correct for the file.
            if (Path.GetExtension(file.FileName) != ".csv" || 
                !Constants.CsvAcceptedContentType.Contains(file.ContentType.ToLower(CultureInfo.InvariantCulture)))
                    throw new ApiException("Csv content only accepted").AddApiExceptionResponseDetails(ErrorTypeCode.ValidationError, ErrorCode.Invalid, SOURCE);
            // Read csv content.
            var content = await file.ReadCsvAsync<OrderCsvResponseDto>() as CsvProcessedResponseDto<OrderCsvResponseDto>;
            await ProcessBulkUpload(content);
            // Return information about the csv file.
            return Ok(content);
        }
        internal async Task ProcessBulkUpload(CsvProcessedResponseDto<OrderCsvResponseDto> content)
        {
             // do some processing...
        }
