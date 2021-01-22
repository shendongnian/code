              foreach (string files2 in paths)
              {
                string filenameOnly = System.IO.Path.GetFileName(files2);
                string pathOnly = System.IO.Path.GetDirectoryName(files2);
                string sanitizedFileName = regExPattern.Replace(filenameOnly, replacement);
                sanitizedFileName = regExPattern2.Replace(sanitizedFileName, replacement); // clean up whitespace
                string sanitized = System.IO.Path.Combine(pathOnly, sanitizedFileName);
