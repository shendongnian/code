        /// <summary>This method throws an exception.</summary>
        /// <param name="myPath">A path to a directory that will be zipped.</param>
        /// <exception cref="IOException">This exception is thrown if the archive already exists</exception>
        public void FooThrowsAnException (string myPath)
        {
            // This will throw an IO exception
            ZipFile.CreateFromDirectory(myPath);
        }
