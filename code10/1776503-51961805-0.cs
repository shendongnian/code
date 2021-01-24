     public async Task setOutFile(StorageFolder folder)
        {
            var rand = new Random();
            string charset = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(13);
            for (int i=0; i<13; i++)
            {
                result.Append(charset[rand.Next(charset.Length)]);
            }
            StringBuilder outputName = new StringBuilder();
            outputName.Append(inputName.Substring(0, inputName.Length - 4));
            outputName.Append("_");
            outputName.Append(result);
            outputName.Append(".txt");
            this.outputName = outputName.ToString();
            if (folder != null)
            {
                outputFile = await folder.CreateFileAsync(outputName.ToString(), CreationCollisionOption.ReplaceExisting);
            }
        }
