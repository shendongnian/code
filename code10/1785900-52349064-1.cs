        private void CreateTempCopy()
        {
            _logger?.WriteLine("Creating temporary file...");
            _logger?.WriteLine(_tempFilePath);
            File.Copy(AaTrendLocation, _tempFilePath);
        }
        private string GenerateTempFileName(int increment = 0)
        {
            string directory = Path.GetDirectoryName(AaTrendLocation); //Obtain pass components.
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(AaTrendLocation);
            string extension = Path.GetExtension(AaTrendLocation);
            string tempName = $"{directory}\\{fileNameWithoutExtension}-{increment}{extension}"; //Re-assemble path with increment inserted.
            return File.Exists(tempName) ? GenerateTempFileName(++increment) : tempName; //If this name is already used, increment an recurse otherwise return new path.
        }
