                    Metadata.Entry metadataEntry = context.RequestHeaders.FirstOrDefault(m =>
                String.Equals(m.Key, "token", StringComparison.Ordinal));
                if (metadataEntry.Equals(default(Metadata.Entry)) || metadataEntry.Value == null)
                {
                    return null;
                }
                Console.WriteLine("Token value is {0}", metadataEntry.Value);
