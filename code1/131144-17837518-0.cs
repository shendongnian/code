    Dim MyTaglibMP3 As TagLib.File = TagLib.File.Create("C:\temp\I'm Alive.mp3")
    Dim id3v2tag As TagLib.Id3v2.Tag = CType(MyTaglibMP3.GetTag(TagLib.TagTypes.Id3v2), TagLib.Id3v2.Tag)
    Dim AcoustidDurationTXXXFrame As New TagLib.Id3v2.UserTextInformationFrame("Acoustid Duration", TagLib.StringType.UTF16)
    AcoustidDurationTXXXFrame.Text = {"207"}
    id3v2tag.AddFrame(AcoustidDurationTXXXFrame)
    ...
    MyTaglibMP3.Save()
    MyTaglibMP3.Dispose()
