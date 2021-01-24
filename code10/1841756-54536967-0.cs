		/// <summary>
		/// Return the zip file for the requested id.
		/// </summary>
		/// <param name="externalId">Report external id</param>
		public async Task<IActionResult> OnPostDownloadFileAsync(string externalId) {
			var report = LoadReport();
			if (report == null) {
				return Page();
			}
			var zipFile = report.GetReportDownload();
			string filename = FileUtils.WebSafeFileName(zipFile, ".zip");
			return PhysicalFile(zipFile, "application/zip", filename);
		}
