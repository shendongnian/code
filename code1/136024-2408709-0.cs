    // create the SFX
    using (ZipFile zip1 = new ZipFile())
    {
        zip1.AddFile(filename1, "");       // extract to toplevel
        zip1.AddFile(filename2, "subdir"); // extract to subdir
        zip1.AddFile(filename3, "subdir");
        zip1.Comment = "This will be embedded into a self-extracting exe";
        zip1.AddEntry("Readme.txt", "This is Update XXX of product YYY");
        SelfExtractorSaveOptions sfxOptions = new SelfExtractorSaveOptions {
            Flavor = SelfExtractorFlavor.WinFormsApplication,
            Quiet = false,  // false == show a UI
            DefaultExtractDirectory = UnpackDirectory
        }
        zip1.SaveSelfExtractor(SfxFileToCreate, sfxOptions);
    }
