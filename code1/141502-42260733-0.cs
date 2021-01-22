		var tests = new[] {
			Path.GetTempFileName(),
			Path.GetDirectoryName(Path.GetTempFileName()),
			"http://in.ter.net",
			"http://in.ter.net/",
			"http://in.ter.net/subfolder/",
			"http://in.ter.net/subfolder/filenoext",
			"http://in.ter.net/subfolder/file.ext",
			"http://in.ter.net/subfolder/file.ext?somequerystring=yes",
			Path.GetFileName(Path.GetTempFileName()),
			Path.Combine("subfolder", Path.GetFileName(Path.GetTempFileName())),
		};
		
		tests.Select(test => {
			Uri u;
			try {
				u = new Uri(test);
			} catch(Exception ex) {
				return new {
					test,
					IsAbsoluteUri = false,
					// just assume
					IsFile = true,
				};
			}
			
			return new {
				test,
				u.IsAbsoluteUri,
				u.IsFile,
			};
		}).Dump();
