    private static void FixAlbumArt(FileInfo MyFile)
    {
      //Find the jpeg file in the directory of the Mp3 File
      //We will embed this image into the ID3v2 tag
      FileInfo[] fiAlbumArt = MyFile.Directory.GetFiles("*.jpg");
      if (fiAlbumArt.Length &lt; 1)
      {
        Console.WriteLine("No Album Art Found in {0}", MyFile.Directory.Name);
        return;
      }
      string AlbumArtFile = fiAlbumArt[0].FullName;
    
      //Create Mp3 Object
      UltraID3 myMp3 = new UltraID3();
      myMp3.Read(MyFile.FullName);
      ID3FrameCollection myArtworkCollection =
        myMp3.ID3v23Tag.Frames.GetFrames(MultipleInstanceFrameTypes.Picture);
    
      if (myArtworkCollection.Count &gt; 0)
      {//Get Rid of the Bad Embedded Artwork
        #region Remove All Old Artwork
        for (int i = 0; i &lt; myArtworkCollection.Count; i++)
        {
          ID3PictureFrame ra = (ID3PictureFrame)myArtworkCollection[0];
          try
          {
            myMp3.ID3v23Tag.Frames.Remove(FrameTypes.Picture);
          }
          catch { }
        }
        myArtworkCollection.Clear();
    
         //Save out our changes so that we are working with the
        //most up to date file and tags
        myMp3.ID3v23Tag.WriteFlag = true;
        myMp3.Write();
        myMp3.Read(MyFile.FullName);
        #endregion Remove All Old Artwork
      }
      //Create a PictureFrame object, pointing it at the image on my PC
      ID3PictureFrame AlbumArt =
        new ID3PictureFrame(
        (System.Drawing.Bitmap)System.Drawing.Bitmap.FromFile(AlbumArtFile),
        PictureTypes.CoverFront, "Attached picture", TextEncodingTypes.ISO88591);
      myMp3.ID3v23Tag.Frames.Add(AlbumArt);
      myMp3.ID3v23Tag.WriteFlag = true;
      myMp3.Write();
    
      myMp3 = null;
    }
