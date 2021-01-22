    using (var archive = RarArchive.Open("Rar.multi.part01.rar")))
    {
        Assert.IsTrue(archive.IsMultipartVolume());
        Assert.IsTrue(archive.IsFirstVolume());
    }
