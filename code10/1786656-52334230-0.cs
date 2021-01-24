    public static void CheckRotation(string imageFilePath, string templateFilePath, int tryCount)
        {
          if (tryCount > 2)
            throw new Exception("the Image Cant be Detected");
    
          int leftTotal = 0;
          int leftBlackColor = 0;
    
          int rightTotal = 0;
          int rightBlackColor = 0;
    
          byte findLeftAndRight = 0;
    
          OmrTemplate template = OmrTemplate.Load(templateFilePath);
          OmrImage image = OmrImage.Load(imageFilePath);
          OmrEngine engine = new OmrEngine(template);
          image.AutoDetectResolution = true;
    
          OmrProcessingResult result = engine.ExtractData(new OmrImage[] { image });
          Hashtable OmrResult = result.PageData[0];
          ICollection key = OmrResult.Keys;
    
          OmrElementsCollection collection = template.Pages[0].Elements;
          foreach (Object obj in collection)
          {
            if (obj.GetType() == typeof(ChoiceBoxElement))
            {
              var elem = (ChoiceBoxElement)obj;
    
              if (elem.Name.ToString().ToUpper() == "LEFT" || elem.Name.ToString().ToUpper() == "RIGHT")
              {
                findLeftAndRight++;
    
                var xPosition = int.Parse(Math.Floor((elem.Position.X * 150) / 25.4).ToString()) + 1;
                var yPosition = int.Parse(Math.Floor((elem.Position.Y * 150) / 25.4).ToString()) + 1;
    
                Bitmap bitmap = new Bitmap(imageFilePath);
                BitmapData data = bitmap.LockBits(new System.Drawing.Rectangle(xPosition, yPosition, int.Parse(Math.Floor((elem.Size.Width * 150) / 25.4).ToString()), int.Parse(Math.Floor((elem.Size.Height * 150) / 25.4).ToString())),
                ImageLockMode.ReadOnly, bitmap.PixelFormat);  // make sure you check the pixel format as you will be looking directly at memory
    
                unsafe
                {
                  // example assumes 24bpp image.  You need to verify your pixel depth
                  // loop by row for better data locality
                  for (int y = 0; y < data.Height; ++y)
                  {
                    byte* pRow = (byte*)data.Scan0 + y * data.Stride;
                    for (int x = 0; x < data.Width; ++x)
                    {
                      // windows stores images in BGR pixel order
                      byte r = pRow[2];
                      byte g = pRow[1];
                      byte b = pRow[0];
    
                      if (elem.Name.ToString().ToUpper() == "LEFT")
                        leftTotal++;
                      else if (elem.Name.ToString().ToUpper() == "RIGHT")
                        rightTotal++;
    
                      if (
                          (r == 0 && g == 0 && b == 0) ||
                          ((r < 100 && g < 100) || (r < 100 && b < 100) || (b < 100 && g < 100)) ||
                          (r < 120 && g < 120 && b < 120 && Math.Abs(r - g) < 10 && Math.Abs(r - b) < 10 && Math.Abs(b - g) < 10)
                        )
                      {
                        if (elem.Name.ToString().ToUpper() == "LEFT")
                          leftBlackColor++;
                        else if (elem.Name.ToString().ToUpper() == "RIGHT")
                          rightBlackColor++;
                      }
    
    
                      // next pixel in the row
                      pRow += 3;
                    }
                  }
                }
    
                bitmap.UnlockBits(data);
              }
            }
          }
    
          if (findLeftAndRight != 2)
            throw new Exception("The Left and Right Mark Didnt Exists!!");
    
          var leftPercentage = (leftBlackColor / leftTotal) * 100;
          var rightPercentage = (rightBlackColor / rightTotal) * 100;
    
          if (leftPercentage > 80 && rightPercentage > 80) //It means The Paper is Currect Rotation
            return;
          else
          {
            RotateImage(imageFilePath, 180);
            CheckRotation(imageFilePath, templateFilePath, ++tryCount);
          }
    
    
        }
