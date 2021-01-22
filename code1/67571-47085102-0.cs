    using (var inputSplitStream = new ReadableSplitStream(inputSourceStream))
    using (var inputFileStream = inputSplitStream.GetForwardReadOnlyStream())
    using (var outputFileStream = File.OpenWrite("MyFileOnAnyFilestore.bin"))
    using (var inputSha1Stream = inputSplitStream.GetForwardReadOnlyStream())
    using (var outputSha1Stream = SHA1.Create())
    {
        inputSplitStream.StartReadAhead();
        Parallel.Invoke(
            () => {
                var bytes = outputSha1Stream.ComputeHash(inputSha1Stream);
                var checksumSha1 = string.Join("", bytes.Select(x => x.ToString("x")));
            },
            () => {
                inputFileStream.CopyTo(outputFileStream);
            },
        );
    }
