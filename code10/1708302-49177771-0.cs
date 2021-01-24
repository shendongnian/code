            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.Length > 280)
                        continue;
                    entry.ExtractToFile(Path.Combine("your path", entry.FullName));
                }
            } 
